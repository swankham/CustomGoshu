using Erp.Custom.SecurityAuth.Enums;
using Erp.Custom.SecurityAuth.Models;
using Erp.Custom.SecurityAuth.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ice.CustomUI.PRList
{
    public class ApprovalModel
    {
        private readonly IAuth _repo;

        public ApprovalModel()
        {
            this.ActionTrees = new List<TreeStartModel>();
            this._repo = new AuthRepo();
        }

        public string Company { get; set; }

        public string Plant { get; set; }

        public string OrderNum { get; set; }

        public int OrderType { get; set; }

        public string OrderTypeStr
        {
            get
            {
                return Enum.GetName(typeof(OrderType), OrderType);
            }
        }

        public string RequestorId { get; set; }

        public string RequestorName { get; set; }

        public int ActionTreeId { get; set; }

        public string ActionTree { get; set; }

        public string WaitForApproveTeamId { get; set; }

        public string CurrentApproveTeamId { get; set; }

        public IList<TreeStartModel> ActionTrees { get; set; }

        public string DepatcherTeam { get; set; }

        public string DispatcherRemark { get; set; }

        public string ReplyRemark { get; set; }

        public bool ApproveFlag { get; set; }

        //public void Load()
        //{
        //    if (ActionTreeId == 0)
        //    {
        //        ActionTrees = _repo.GetStartTreeByUser(RequestorId).Where(x => x.TeamId.Equals(WaitForApproveTeamId)).ToList();
        //    }
        //    else
        //    {
        //        ActionTrees = _repo.GetStartTreeByUser(RequestorId).ToList();
        //    }
            
        //}
    }
}