using Erp.Custom.Core.Session.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ice.CustomUI.PRList
{
    public interface IRequisition
    {
        IEnumerable<ReqHeadModel> GetAll(string teams, string t);

        ReqHeadModel GetByID(int ReqNum);

        bool SaveApprove(CustomSession _session, ApprovalModel model, ReqHeadModel reqHead);

        bool SendToPOSuggestions(CustomSession _session, ReqHeadModel model, out string resultMessage);


        IEnumerable<BuyerModel> GetAllBuyer(string company, string userId);

        IEnumerable<BuyerModel> BuyerByFilter(string company, string userId, BuyerModel model);

        BuyerModel GetBuyer(string id);

        string GetDefualtBuyer(string requestorId);

    }
}
