using Erp.Custom.Core.Session.Epicor.ReqSvc;
using Erp.Custom.Core.Session.Epicor.SessionModSvc;
using Erp.Custom.Core.Session.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Custom.Core.Session.Repositories
{
    public class RequisitionSvc
    {
        private readonly ISession _s;
        private EndpointBindingSvc _inst;
        private CustomSession epiSession;

        public RequisitionSvc(CustomSession _session)
        {
            this.epiSession = _session;
            this._inst = new EndpointBindingSvc(epiSession);
            this._s = new Session();
        }

        public bool ReqToPOSug(CustomSession _session, out string resultMessage)
        {
            Erp.Custom.Core.Session.EndpointBindingSvc.EndpointBindingType bindingType;
            resultMessage = string.Empty;
            bool result = false;
            UriBuilder builder = _inst.EndpointBinding(out bindingType);
            SessionModSvcContractClient sessionModClient = _inst.IdentifiesSession(_session);

            builder.Path = _inst.epiSite + "/Erp/BO/Req.svc";
            ReqSvcContractClient reqClient = _inst.GetClient<ReqSvcContractClient, ReqSvcContract>(builder.Uri.ToString(), _session.UserId, _session.Password, bindingType);

            Guid sessionId = Guid.Empty;
            try
            {
                sessionId = sessionModClient.Login();
                sessionModClient.Endpoint.Behaviors.Add(new HookServiceBehavior(sessionId, epiSession.UserId));
                reqClient.Endpoint.Behaviors.Add(new HookServiceBehavior(sessionId, epiSession.UserId));
                var ts = new ReqTableset();
                ts = reqClient.GetByID(108);

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
                ts.ReqHead[0].RowMod = "U";

                try
                {
                    reqClient.Update(ref ts);
                    result = true;
                }
                catch (FaultException<Epicor.ReqSvc.EpicorFaultDetail> ex)
                {
                    if (ex.Detail.ExceptionKindValue.Equals("RecordNotFound", StringComparison.InvariantCultureIgnoreCase))
                    {
                        resultMessage = "Record deleted.";
                    }
                    else
                    {
                        resultMessage = ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                resultMessage = "ex" + ex.Message;
                sessionModClient.Logout();
                return result;
            }

            return result;
        }
    }
}
