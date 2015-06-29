using Erp.Custom.Core.DataService.SQL;
using Erp.Custom.Core.Session;
using Erp.Custom.Core.Session.Epicor.SessionModSvc;
using Erp.Custom.Core.Session.Epicor.UD07Svc;
using Erp.Custom.Core.Session.Models;
using Erp.Custom.Core.Session.Repositories;
using Erp.Custom.CostManagement.Models;
using Erp.Custom.SecurityAuth.Repositories;
using Ice.Lib.Framework;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Erp.Custom.CostManagement
{
    public class Repositories : IEstimate
    {
        private readonly IAuth _repo;
        private readonly ISession _s;

        private EndpointBindingSvc _inst;

        public Repositories()
        {
            CustomSession ses = new CustomSession();
            this._s = new Session();
            this._repo = new AuthRepo();
            this._inst = new EndpointBindingSvc(ses);
        }

        #region IEstimateRunning

        public EstimateRunningModel GetLastRow(string teamid)
        {
            string sql = string.Format(@"SELECT TOP 1 * FROM Ice.UD07 NOLOCK WHERE Key4 = '{0}' ORDER BY Key2 DESC, Key3 DESC", teamid);
            return Repository.Instance.GetOne<EstimateRunningModel>(sql);
        }

        public EstimateRunningModel GetExistingRow(int quoteNo)
        {
            string sql = string.Format(@"SELECT TOP 1 * FROM Ice.UD07 NOLOCK WHERE Key3 = '{0}' ORDER BY Key2, Key3 DESC", quoteNo);
            return Repository.Instance.GetOne<EstimateRunningModel>(sql);
        }

        public EstimateRunningModel GetRowByID(string estimateNo, int revNo)
        {
            string sql = string.Format(@"SELECT TOP 1 * FROM Ice.UD07 NOLOCK WHERE Key1 = '{0}' AND Number02 = {1}", estimateNo, revNo);
            return Repository.Instance.GetOne<EstimateRunningModel>(sql);
        }

        public bool CheckExitingEstimate(string estimateNo)
        {
            int result = 0;
            string sql = string.Format(@"SELECT Count(*) as rows FROM QuoteHed NOLOCK WHERE EstimateNo_c = '{0}'", estimateNo);
            result = Repository.Instance.GetOne<int>(sql, "rows");

            return (result != 0);
        }

        public bool CheckStatusEstimate(string estimateNo, string estimateRev, int status)
        {
            throw new NotImplementedException();
        }

        public string GetLastRunning(Ice.Core.Session _session, string teamid, int quoteNo)
        {
            var team = _repo.GetTeamByUserID(_session.UserID);
            EstimateRunningModel model = new EstimateRunningModel();
            int iRn = 1;
            string no = "";

            if (quoteNo == 0) return no;

            model = GetExistingRow(quoteNo);

            if (model == null)
            {
                model = GetLastRow(team);
                if (model != null) iRn = model.RunningNo + 1;
                no = string.Format(@"{0}E{1:00}{2:00}{3:000}", team, DateTime.Now.ToString("yy"), DateTime.Now.ToString("MM"), iRn);
            }
            else
            {
                iRn = model.RunningNo;
                no = model.EstimateNo;
            }

            string outResult = string.Empty;
            EstimateRunningModel est = new EstimateRunningModel();
            est.TeamId = team;
            est.RunningNo = iRn;
            est.EstimateNo = no;
            est.QuoteNumber = quoteNo;
            est.GeneratedPerson = _session.UserID;
            CustomSession custSession = _s.GetSessionForWCFAccount();
            NewRunningRow(custSession, est, out outResult);
            return no;
        }

        public bool NewRunningRow(CustomSession session, EstimateRunningModel model, out string resultMessage)
        {
            Erp.Custom.Core.Session.EndpointBindingSvc.EndpointBindingType bindingType;
            resultMessage = string.Empty;
            bool result = false;
            UriBuilder builder = _inst.EndpointBinding(out bindingType);
            SessionModSvcContractClient sessionModClient = _inst.IdentifiesSession(session);

            builder.Path = _inst.epiSite + "/Ice/BO/UD07.svc";
            UD07SvcContractClient ud07Client = _inst.GetClient<UD07SvcContractClient, UD07SvcContract>(builder.Uri.ToString(), session.UserId, session.Password, bindingType);

            Guid sessionId = Guid.Empty;
            try
            {
                sessionId = sessionModClient.Login();
                sessionModClient.Endpoint.Behaviors.Add(new HookServiceBehavior(sessionId, session.UserId));
                ud07Client.Endpoint.Behaviors.Add(new HookServiceBehavior(sessionId, session.UserId));
                var ts = new UD07Tableset();

                ud07Client.GetaNewUD07(ref ts);

                ts.UD07[0].Key1 = model.EstimateNo;
                ts.UD07[0].Key2 = model.RunningNo.ToString();
                ts.UD07[0].Key3 = model.QuoteNumber.ToString();
                ts.UD07[0].Key4 = model.TeamId;
                ts.UD07[0].Key5 = model.GeneratedPerson;
                ts.UD07[0].Date01 = DateTime.Now;
                ts.UD07[0].RowMod = "A";

                try
                {
                    ud07Client.Update(ref ts);
                    result = true;
                }
                catch (FaultException<Erp.Custom.Core.Session.Epicor.ReqSvc.EpicorFaultDetail> ex)
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

        public CostRequestModel Save(CustomSession session, CostRequestModel model, bool insertFlag, out string resultMessage)
        {
            CostRequestModel result = new CostRequestModel();
            CustomSession custSession = _s.GetSessionForWCFAccount();
            Erp.Custom.Core.Session.EndpointBindingSvc.EndpointBindingType bindingType;
            resultMessage = "Save Completed.";// +Environment.NewLine +
            //"EstimateNo = " + model.GKCStadardFlag + Environment.NewLine +
            //"ReviseNo = " + model.ReviseNo + Environment.NewLine +
            //"RevisionStr = " + model.RevisionStr;


            string sRowMod = string.Empty;

            UriBuilder builder = _inst.EndpointBinding(out bindingType);
            SessionModSvcContractClient sessionModClient = _inst.IdentifiesSession(custSession);

            builder.Path = _inst.epiSite + "/Ice/BO/UD07.svc";
            UD07SvcContractClient ud07Client = _inst.GetClient<UD07SvcContractClient, UD07SvcContract>(builder.Uri.ToString(), custSession.UserId, custSession.Password, bindingType);

            //resultMessage = resultMessage + Environment.NewLine + "Binded.";
            Guid sessionId = Guid.Empty;
            try
            {
                sessionId = sessionModClient.Login();
                sessionModClient.Endpoint.Behaviors.Add(new HookServiceBehavior(sessionId, custSession.UserId));
                ud07Client.Endpoint.Behaviors.Add(new HookServiceBehavior(sessionId, custSession.UserId));

                //resultMessage = resultMessage + Environment.NewLine + "GUID : " + sessionId;
                var ts = new UD07Tableset();
                
                if (!insertFlag)
                {
                    var row = GetRowByID(model.EstimateNo, model.ReviseNo);
                    ts = ud07Client.GetByID(row.EstimateNo, row.RevisionStr.Trim(), row.RunningNo.ToString(), row.TeamId, row.GeneratedPerson);                    
                    sRowMod = "U";
                }
                else
                {
                    int iRn = 1;
                    ud07Client.GetaNewUD07(ref ts);
                    sRowMod = "A";
                    if (string.IsNullOrEmpty(model.EstimateNo))
                    {
                        var res = GetLastRow(model.TeamId);
                        if (model != null) iRn = ((res == null) ? 0 : res.RunningNo) + 1;
                        model.EstimateNo = string.Format(@"{0}E{1:00}{2:00}{3:000}", model.TeamId, DateTime.Now.ToString("yy"), DateTime.Now.ToString("MM"), iRn);
                        model.ReviseNo = 0;
                        model.RunningNo = iRn;
                        model.RequestBy = session.UserId;
                    }
                    else
                    {
                        model.ReviseNo = GetLastRow(model.TeamId).ReviseNo + 1;
                    }

                    ts.UD07[0].Key1 = model.EstimateNo;
                    ts.UD07[0].Key2 = string.IsNullOrEmpty(Enum.GetName(typeof(RevisionEnum), Convert.ToInt32(Convert.ToInt32((model.ReviseNo.GetInt() == 0) ? 0 : model.ReviseNo)))) ? string.Empty : Enum.GetName(typeof(RevisionEnum), Convert.ToInt32(Convert.ToInt32((model.ReviseNo.GetInt() == 0) ? 0 : model.ReviseNo)));
                    ts.UD07[0].Key3 = model.RunningNo.GetString();
                    ts.UD07[0].Number02 = model.ReviseNo.GetInt();
                    ts.UD07[0].Key4 = model.TeamId;
                    ts.UD07[0].Key5 = model.RequestBy;

                }

                ts.UD07[0].Character01 = string.IsNullOrEmpty(model.ProjectName) ? "" : model.ProjectName;
                ts.UD07[0].Character03 = string.IsNullOrEmpty(model.OtherRemark) ? "" : model.OtherRemark;
                ts.UD07[0].Character04 = string.IsNullOrEmpty(model.Remarks) ? "" : model.Remarks;
                ts.UD07[0].Character05 = string.IsNullOrEmpty(model.Location) ? "" : model.Location;
                ts.UD07[0].Number01 = model.Budget;
                ts.UD07[0].CheckBox01 = model.GKCStadardFlag;
                ts.UD07[0].CheckBox02 = model.JisFlag;
                ts.UD07[0].CheckBox03 = model.ANSFlag;
                ts.UD07[0].CheckBox04 = model.CustomerSpecFlag;
                ts.UD07[0].CheckBox05 = model.DinFlag;
                ts.UD07[0].CheckBox06 = model.OtherFlag;
                ts.UD07[0].CheckBox07 = model.EstimateByCostFlag;
                //ts.UD07[0].CheckBox08 = model.EstimateByOwner;
                ts.UD07[0].ShortChar01 = string.IsNullOrEmpty(model.CustomerName) ? "" : model.CustomerName;
                ts.UD07[0].ShortChar02 = string.IsNullOrEmpty(model.Ref_ProjectID) ? "" : model.Ref_ProjectID;

                ts.UD07[0].Date01 = model.RequestDate;
                ts.UD07[0].RowMod = sRowMod;
                //resultMessage = resultMessage + Environment.NewLine + "RowMod : " + sRowMod + model.ToString();

                try
                {
                    ud07Client.Update(ref ts);
                }
                catch (FaultException<Erp.Custom.Core.Session.Epicor.ReqSvc.EpicorFaultDetail> ex)
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
                catch (Exception x)
                {
                    resultMessage = x.Message;
                }
                result = GetEstimateByID(model.EstimateNo, model.ReviseNo.GetString());
            }
            catch (Exception ex)
            {
                resultMessage = "Error Code : 20055 " + ex.Message + Environment.NewLine + "Source : " + ex.Source + Environment.NewLine + "StackTrace : " + ex.StackTrace;
                sessionModClient.Logout();
            }

            //sessionModClient.Logout();
            return result;
        }

        #endregion IEstimateRunning

        #region UI Forms

        public IEnumerable<CostRequestModel> GetEstimateAll(string teamid)
        {
            string sql = string.Format(@"SELECT ud.* FROM Ice.UD07 as ud 
                                            WHERE ud.Key4 = '{0}'
                                            AND (select max(status_c) as stus from QuoteHed where EstimateNo_c = ud.Key1 and Revision_c = ud.Key2) = 0
                                            ORDER BY ud.Key2 DESC", teamid);
            return Repository.Instance.GetMany<CostRequestModel>(sql);
        }

        public CostRequestModel GetEstimateByID(string estimateId, string reviseNo)
        {
            string sql = string.Format(@"SELECT * FROM Ice.UD07 NOLOCK WHERE Key1 = '{0}' AND Number02 = {1}", estimateId, reviseNo);
            return Repository.Instance.GetOne<CostRequestModel>(sql);
        }

        #endregion UI Forms

        public bool QuoteValidation(EpiDataView edvQuote, out bool ignoreFlag, out string resultMsg)
        {
            ignoreFlag = true;
            resultMsg = "Test message!.";
            return false;
        }
    }
}