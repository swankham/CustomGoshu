using Erp.Custom.Core.Session.Epicor.ReqSvc;
using Erp.Custom.Core.Session.Epicor.SessionModSvc;
using Erp.Custom.Core.Session.Models;
using Erp.Custom.Core.Session.Repositories;
using System;
using System.Linq;
using System.Net;
using System.Reflection;
using System.ServiceModel;

namespace Erp.Custom.Core.Session
{
    public class EndpointBindingSvc
    {
        public EndpointBindingType bindingType;
        public string scheme;
        public string epiServer;
        public string epiSite;
        public string epiUserWCF;
        public string epiPassWCF;

        private readonly ISession _repo;
        private CustomSession epiSession;

        public EndpointBindingSvc(CustomSession session)
        {
            this.epiSession = session;
            this._repo = new Erp.Custom.Core.Session.Repositories.Session();
            String[] arguments = Environment.GetCommandLineArgs();
            var result = _repo.ProcessCommandLineArguments(arguments);
            epiServer = result.FirstOrDefault(x => x.Key.Equals("epiServer")).Value;
            epiSite = result.FirstOrDefault(x => x.Key.Equals("epiSite")).Value;
            epiUserWCF = result.FirstOrDefault(x => x.Key.Equals("ActiveServcieWCFUser")).Value;
            epiPassWCF = result.FirstOrDefault(x => x.Key.Equals("ActiveServcieWCFPassword")).Value;
        }

        public enum EndpointBindingType
        {
            SOAPHttp,
            BasicHttp
        }

        private static WSHttpBinding GetWsHttpBinding()
        {
            var binding = new WSHttpBinding();
            const int maxBindingSize = Int32.MaxValue;
            binding.MaxReceivedMessageSize = maxBindingSize;
            binding.ReaderQuotas.MaxDepth = maxBindingSize;
            binding.ReaderQuotas.MaxStringContentLength = maxBindingSize;
            binding.ReaderQuotas.MaxArrayLength = maxBindingSize;
            binding.ReaderQuotas.MaxBytesPerRead = maxBindingSize;
            binding.ReaderQuotas.MaxNameTableCharCount = maxBindingSize;
            binding.Security.Mode = SecurityMode.Message;
            binding.Security.Message.ClientCredentialType = MessageCredentialType.UserName;
            return binding;
        }

        private static BasicHttpBinding GetBasicHttpBinding()
        {
            var binding = new BasicHttpBinding();
            const int maxBindingSize = Int32.MaxValue;
            binding.MaxReceivedMessageSize = maxBindingSize;
            binding.ReaderQuotas.MaxDepth = maxBindingSize;
            binding.ReaderQuotas.MaxStringContentLength = maxBindingSize;
            binding.ReaderQuotas.MaxArrayLength = maxBindingSize;
            binding.ReaderQuotas.MaxBytesPerRead = maxBindingSize;
            binding.ReaderQuotas.MaxNameTableCharCount = maxBindingSize;
            binding.Security.Mode = BasicHttpSecurityMode.TransportWithMessageCredential;
            binding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
            return binding;
        }

        public TClient GetClient<TClient, TInterface>(string url, string user, string pass, EndpointBindingType bindingType)
            where TClient : ClientBase<TInterface>
            where TInterface : class
        {
            System.ServiceModel.Channels.Binding binding = null;
            TClient client;
            var endpointAddress = new EndpointAddress(url);
            switch (bindingType)
            {
                case EndpointBindingType.BasicHttp:
                    binding = GetBasicHttpBinding();
                    break;

                case EndpointBindingType.SOAPHttp:
                    binding = GetWsHttpBinding();
                    break;
            }
            TimeSpan operationTimeout = new TimeSpan(0, 12, 0);
            binding.CloseTimeout = operationTimeout;
            binding.ReceiveTimeout = operationTimeout;
            binding.SendTimeout = operationTimeout;
            binding.OpenTimeout = operationTimeout;

            client = (TClient)Activator.CreateInstance(typeof(TClient), binding, endpointAddress);
            if (!string.IsNullOrEmpty(user) && (client.ClientCredentials != null))
            {
                client.ClientCredentials.UserName.UserName = user;
                client.ClientCredentials.UserName.Password = pass;
            }
            return client;
        }

        public UriBuilder EndpointBinding(out EndpointBindingType bindingType)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, errors) => { return true; };

            bindingType = EndpointBindingType.BasicHttp;

            scheme = "http";
            if (bindingType == EndpointBindingType.BasicHttp)
            {
                scheme = "https";
            }

            UriBuilder builder = new UriBuilder(scheme, epiServer);
            return builder;
        }

        public SessionModSvcContractClient IdentifiesSession(CustomSession session)
        {
            UriBuilder builder = EndpointBinding(out bindingType);
            builder.Path = epiSite + "/Ice/Lib/SessionMod.svc";
            SessionModSvcContractClient sessionModClient = GetClient<SessionModSvcContractClient, SessionModSvcContract>(builder.Uri.ToString(), session.UserId, session.Password, bindingType);

            return sessionModClient;
        }

        public void GetSessionModClient(CustomSession session)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, errors) => { return true; };

            bindingType = EndpointBindingType.BasicHttp;

            scheme = "http";
            if (bindingType == EndpointBindingType.BasicHttp)
            {
                scheme = "https";
            }
            UriBuilder builder = new UriBuilder(scheme, epiServer);

            builder.Path = epiSite + "/Ice/Lib/SessionMod.svc";
            SessionModSvcContractClient sessionModClient = GetClient<SessionModSvcContractClient, SessionModSvcContract>(builder.Uri.ToString(), session.UserId, session.Password, bindingType);

            builder.Path = epiSite + "/Erp/BO/Req.svc";
            ReqSvcContractClient reqClient = GetClient<ReqSvcContractClient, ReqSvcContract>(builder.Uri.ToString(), session.UserId, session.Password, bindingType);

            Guid sessionId = Guid.Empty;
            try
            {
                sessionId = sessionModClient.Login();
                sessionModClient.Endpoint.Behaviors.Add(new HookServiceBehavior(sessionId, epiSession.UserId));
                reqClient.Endpoint.Behaviors.Add(new HookServiceBehavior(sessionId, epiSession.UserId));
                var ts = new ReqTableset();
                ts = reqClient.GetByID(86);

                if (ts != null && ts.ReqHead.Any())
                {
                    ReqHeadRow backupRow = new ReqHeadRow();
                    var fields = backupRow.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
                    foreach (var field in fields)
                    {
                        if (field.PropertyType == typeof(System.Runtime.Serialization.ExtensionDataObject))
                        {
                            continue;
                        }

                        var fieldValue = field.GetValue(ts.ReqHead[0]);
                        field.SetValue(backupRow, fieldValue);
                    }
                    ts.ReqHead.Add(backupRow);
                }

                ts.ReqHead[0].NextActionID = "03";
                ts.ReqHead[0].NextActionDesc = "Send to Procurement Dept";
                ts.ReqHead[0].ReplyOption = "A";
                ts.ReqHead[0].ReqUserId = "Manager";
                ts.ReqHead[0].Note = "";
                ts.ReqHead[0].RowMod = "U";

                try
                {
                    reqClient.Update(ref ts);
                }
                catch (FaultException<Epicor.ReqSvc.EpicorFaultDetail> ex)
                {
                    if (ex.Detail.ExceptionKindValue.Equals("RecordNotFound", StringComparison.InvariantCultureIgnoreCase))
                    {
                        Console.WriteLine("Record deleted.");
                    }
                    else
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ex" + ex.Message);
                sessionModClient.Logout();
            }

            if (sessionId != Guid.Empty)
            {
                sessionModClient.Logout();
            }

            sessionModClient.Logout();
        }
    }
}