using Erp.Custom.Core.DataService.SQL;
using Erp.Custom.Core.Session;
using Erp.Custom.Core.Session.Epicor.ReqSvc;
using Erp.Custom.Core.Session.Epicor.SessionModSvc;
using Erp.Custom.Core.Session.Models;
using Erp.Custom.SecurityAuth.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;

namespace Ice.CustomUI.PRList
{
    public class RequisitionRepo : IRequisition
    {
        private EndpointBindingSvc _inst;
        private CustomSession epiSession;
        private readonly IAuth _repoAth;

        public RequisitionRepo(CustomSession _session = null)
        {
            this.epiSession = _session;
            this._inst = new EndpointBindingSvc(epiSession);
            this._repoAth = new AuthRepo();
        }

        public IEnumerable<ReqHeadModel> GetAll(string teams, string t)
        {
            string sql = string.Format(@"SELECT rqh.Company, rqh.RequestDate, rqh.ReqNum, rqh.RequestorID, usr.Name as RequestorName
                                                , rqh.Status_c, rqh.TreeViewID_c, tre.TreeViewName as ActionTree, rqh.ReqActionDesc_c
                                                , rqh.WaitingTeamID_c, rqh.SentByTeam_c
                                            FROM ReqHead rqh
                                            LEFT JOIN UserFile usr ON(rqh.RequestorID = usr.DcdUserID)
                                            LEFT JOIN Custom_Tree tre ON(rqh.TreeViewID_c = tre.TreeViewID)
                                            WHERE 1=1
                                                AND CONCAT(rqh.WaitingTeamID_c, '#', rqh.TreeViewID_c) IN ('{0}')
                                                AND rqh.StatusType = ''
                                                AND rqh.TreeViewID_c != ''
                                            UNION ALL
                                            SELECT rqh.Company, rqh.RequestDate, rqh.ReqNum, rqh.RequestorID, usr.Name as RequestorName
                                                , rqh.Status_c, rqh.TreeViewID_c, tre.TreeViewName as ActionTree, rqh.ReqActionDesc_c
                                                , rqh.WaitingTeamID_c, rqh.SentByTeam_c
                                            FROM ReqHead rqh
                                            LEFT JOIN UserFile usr ON(rqh.RequestorID = usr.DcdUserID)
                                            LEFT JOIN Custom_Tree tre ON(rqh.TreeViewID_c = tre.TreeViewID)
                                            WHERE 1=1
                                                AND rqh.WaitingTeamID_c IN ('{1}')
                                                AND rqh.StatusType = ''
                                                AND rqh.TreeViewID_c = ''", teams, t);
            return Repository.Instance.GetMany<ReqHeadModel>(sql);
        }

        public ReqHeadModel GetByID(int ReqNum)
        {
            string sql = string.Format(@"SELECT rqh.Company, rqh.RequestDate, rqh.ReqNum, rqh.RequestorID, usr.Name as RequestorName
                                                , rqh.Status_c, rqh.TreeViewID_c, tre.TreeViewName as ActionTree, rqh.ReqActionDesc_c
                                                , rqh.WaitingTeamID_c, rqh.SentByTeam_c
                                            FROM ReqHead rqh
                                            LEFT JOIN UserFile usr ON(rqh.RequestorID = usr.DcdUserID)
                                            LEFT JOIN Custom_Tree tre ON(rqh.TreeViewID_c = tre.TreeViewID)
                                            WHERE 1=1 AND rqh.ReqNum = {0}", ReqNum);

            return Repository.Instance.GetOne<ReqHeadModel>(sql);
        }

        public bool SaveApprove(CustomSession _session, ApprovalModel model, ReqHeadModel reqHead)
        {
            var result = GetByID(Convert.ToInt32(model.OrderNum));

            string sql = string.Format(@"UPDATE ReqHead
                                           SET  Status_c = '{1}'
                                              , TreeViewID_c = N'{2}'
                                              , WaitingTeamID_c = N'{3}'
	                                          , ReqActionDesc_c = N'{4}'
                                              , SentByTeam_c = N'{5}'
                                         WHERE ReqNum = {0}" + Environment.NewLine
                                , model.OrderNum
                                , model.ApproveFlag == true ? "2" : "3"
                                , model.ActionTreeId
                                , model.ApproveFlag == true ? model.DepatcherTeam : result.SentByTeam
                                , model.ReplyRemark
                                , model.ApproveFlag == true ? model.WaitForApproveTeamId : "");
            try
            {
                Repository.Instance.ExecuteWithTransaction(sql, "Approve");

                var lv = _repoAth.GetAllTeamsLevel().Where(x => x.TreeViewId.Equals(model.ActionTreeId) && x.TeamId.Equals(model.WaitForApproveTeamId)).OrderByDescending(i => i.Level).FirstOrDefault();
                if (lv.Level == 0)
                {
                    string resultMessage;
                    reqHead.ReqNum = Convert.ToInt32(model.OrderNum);
                    reqHead.NextActionID = "03";
                    reqHead.NextActionDesc = "Purchasing Department";
                    reqHead.ReplyOption = "A";
                    reqHead.ReqUserId = reqHead.RequestorID;

                    SendToPOSuggestions(_session, reqHead, out resultMessage);
                    UpdateBuyer(reqHead.ReqNum, model.DepatcherTeam);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void UpdateBuyer(int p, string d)
        {
            string sql = string.Format(@"UPDATE Erp.SugPoDtl
                                           SET  BuyerID = N'{1}'
                                         WHERE ReqNum = {0}" + Environment.NewLine, p, d);

            Repository.Instance.ExecuteWithTransaction(sql, "Update");
        }

        public bool SendToPOSuggestions(CustomSession _session, ReqHeadModel model, out string resultMessage)
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
                sessionModClient.Endpoint.Behaviors.Add(new HookServiceBehavior(sessionId, _session.UserId));
                reqClient.Endpoint.Behaviors.Add(new HookServiceBehavior(sessionId, _session.UserId));
                var ts = new Erp.Custom.Core.Session.Epicor.ReqSvc.ReqTableset();
                ts = reqClient.GetByID(model.ReqNum);

                if (ts != null && ts.ReqHead.Any())
                {
                    Erp.Custom.Core.Session.Epicor.ReqSvc.ReqHeadRow backupRow = new Erp.Custom.Core.Session.Epicor.ReqSvc.ReqHeadRow();
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

                ts.ReqHead[0].NextActionID = model.NextActionID; //"03";
                ts.ReqHead[0].NextActionDesc = model.NextActionDesc; //"Send to Procurement Dept";
                ts.ReqHead[0].ReplyOption = model.ReplyOption; //"A";
                ts.ReqHead[0].ReqUserId = model.ReqUserId; //"Manager";
                ts.ReqHead[0].RowMod = "U";

                try
                {
                    reqClient.Update(ref ts);
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

        public IEnumerable<BuyerModel> GetAllBuyer(string company, string userId)
        {
            string sql = string.Format(@"SELECT pAh.BuyerID, pAg.Name
                                            FROM Erp.PurAuth pAh
                                            INNER JOIN PurAgent pAg ON(pAh.BuyerID = pAg.BuyerID)
                                            WHERE pAh.Company = N'{0}' AND pAh.DcdUserID = N'{1}' AND pAg.InActive = 0" + Environment.NewLine
                                                                                                                          , company, userId);
            return Repository.Instance.GetMany<BuyerModel>(sql);
        }

        public IEnumerable<BuyerModel> BuyerByFilter(string company, string userId, BuyerModel model)
        {
            IEnumerable<BuyerModel> query = GetAllBuyer(company, userId);

            if (model.BuyerCode != null) { query = query.Where(p => p.BuyerCode.Contains(model.BuyerCode.ToString())); }
            if (model.BuyerName != null) { query = query.Where(p => p.BuyerName.Contains(model.BuyerName.ToString())); }

            return query;
        }

        public BuyerModel GetBuyer(string id)
        {
            string sql = string.Format(@"SELECT * FROM Erp.PurAgent NOLOCK WHERE InActive = 0 AND BuyerID = N'{0}'");
            return Repository.Instance.GetOne<BuyerModel>(sql);
        }

        public string GetDefualtBuyer(string requestorId)
        {
            string sql = string.Format(@"SELECT ag.BuyerID, ag.Name
	                                        FROM UserFile us
	                                        INNER JOIN Ice.UD06 ud ON(us.TeamCode_c = ud.Key1)
	                                        INNER JOIN PurAgent ag ON(ud.Character02 = ag.BuyerID)
	                                        WHERE us.DcdUserID = '{0}'", requestorId);

            return Repository.Instance.GetOne<string>(sql, "BuyerID");
        }

    }
}