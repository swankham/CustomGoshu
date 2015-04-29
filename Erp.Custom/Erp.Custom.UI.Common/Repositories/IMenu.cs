using Erp.Custom.UI.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Custom.UI.Common.Repositories
{
    public interface IMenu
    {
        IEnumerable<MenuModel> GetAllMenu();
    }
}
