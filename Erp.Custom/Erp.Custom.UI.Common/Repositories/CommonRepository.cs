using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Erp.Custom.UI.Common.Models;
using Erp.Custom.Core.Framework;
using Erp.Custom.Core.Session.Models;
using Erp.Custom.Core.DataService.SQL;

namespace Erp.Custom.UI.Common.Repositories
{
    public class CommonRepository : IMenu
    {
        private readonly CustomSession session;
        public CommonRepository(CustomSession _session)
        {
            this.session = _session;
        }

        public IEnumerable<MenuModel> GetAllMenu()
        {
            string sql = string.Format(@"SELECT * FROM Custom_Menu WHERE Enabled = 1 ORDER BY Sequence ASC");
            return Repository.Instance.GetMany<MenuModel>(sql);
        }
    }
}
