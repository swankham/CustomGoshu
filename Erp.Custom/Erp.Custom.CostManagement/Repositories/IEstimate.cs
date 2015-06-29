using Erp.Custom.Core.Session.Models;
using Erp.Custom.CostManagement.Models;
using Ice.Lib.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Custom.CostManagement
{
    public interface IEstimate
    {
        #region IEstimateRunning
        EstimateRunningModel GetLastRow(string teamid);

        EstimateRunningModel GetExistingRow(int quoteNo);

        EstimateRunningModel GetRowByID(string estimateNo, int revNo);

        bool CheckExitingEstimate(string estimateNo);

        /// <summary>
        /// CheckStatusEstimate
        /// </summary>
        /// <param name="estimateNo"></param>
        /// <param name="estimateRev"></param>
        /// <param name="status">0 = Pending, 1 = Approve, 2 = Reject</param>
        /// <returns>Boolean</returns>
        bool CheckStatusEstimate(string estimateNo, string estimateRev, int status);

        string GetLastRunning(Ice.Core.Session _session, string teamid, int quoteNo);

        bool NewRunningRow(CustomSession session, EstimateRunningModel model, out string resultMessage);

        CostRequestModel Save(CustomSession session, CostRequestModel model, bool insertFlag, out string resultMessage);
        #endregion

        #region UI Forms
        IEnumerable<CostRequestModel> GetEstimateAll(string teamid);

        CostRequestModel GetEstimateByID(string estimateId, string reviseNo);

        #endregion
        bool QuoteValidation(EpiDataView edvQuote, out bool ignoreFlag, out string resultMsg);
    }
}
