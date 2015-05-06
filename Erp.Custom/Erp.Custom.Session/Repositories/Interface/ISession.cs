using Erp.Custom.Session.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Custom.Session.Repositories
{
    public interface ISession
    {
        CustomSession IdentifySession(string userName, string userPassword, out string errmsg);

        CustomSession IdentifySession();
    }
}
