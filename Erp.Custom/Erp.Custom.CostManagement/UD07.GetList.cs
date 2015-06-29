using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.ServiceModel;
using Epicor.Data;
using Epicor.Hosting;
using Ice.Contracts;
using Ice.ExtendedData;
using Ice.Lib;
using Ice.Tables;
using Ice.Tablesets;

namespace BpmCustomCode 
{
    public class MyUD07
    {
        public void GetList(
            ref System.String whereClause,
            ref System.Int32 pageSize,
            ref System.Int32 absolutePage,
            ref System.Boolean morePages,
            Ice.Tablesets.UD07ListTableset result)
        {
            // 
            // TODO: Replace the throw statement with any code for an action in UD07.GetList() method invoke
            // 
            result.UD07List.RemoveAll(r => r.Key2.Equals("1"));
        }
    }
}
