using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Erp.Custom.UI.Common.Models;
using Erp.Custom.Framework;

namespace Erp.Custom.UI.Common.Repositories
{
    public class CommonRepository : IMenu
    {
        public IEnumerable<MenuModel> GetAllMenu()
        {
            string sql = string.Format(@"SELECT * FROM Ice.Custom_Menu WHERE Enabled = 1 ORDER BY Sequence ASC");
            return Repository.Instance.GetMany<MenuModel>(sql);
        }
    }
}
