using Erp.Custom.Core.Session.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Custom.Core.Session.Repositories
{
    public interface ISession
    {
        CustomSession IdentifySession(string userName, string userPassword, out string errmsg);

        Dictionary<string, string> ProcessCommandLineArguments(string[] args);

        Ice.Core.Session GetSession();

        CustomSession GetSessionForWCFAccount();
        //CustomSession IdentifySession();
    }
}
