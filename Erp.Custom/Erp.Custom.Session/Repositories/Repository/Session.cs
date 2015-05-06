using Erp.Custom.Session.Models;
using System;
using System.IO;

namespace Erp.Custom.Session.Repositories
{
    public class Session : ISession
    {
        public CustomSession IdentifySession(string userName, string userPassword, out string errmsg)
        {
            errmsg = string.Empty;
            CustomSession sessionResult = new CustomSession();

            try
            {
                Ice.Core.Session curr = new Ice.Core.Session(userName, userPassword
                                        , "net.tcp://GOLLUM/E10Pilot"
                                        , Ice.Core.Session.LicenseType.Default);

                if (!string.IsNullOrEmpty(curr.SessionID))
                {
                    sessionResult.Company = curr.CompanyID;
                    sessionResult.CompanyName = curr.CompanyName;
                    sessionResult.PlantId = curr.PlantID.GetString();
                    sessionResult.PlantName = curr.PlantName.GetString();
                    sessionResult.UserId = curr.UserID;
                    sessionResult.Username = curr.UserName;
                    sessionResult.SessionId = curr.SessionID;
                    sessionResult.Client = curr.Client.ToString();
                    sessionResult.Password = userPassword;
                }

                return sessionResult;               
            }
            catch (Exception ex)
            {
                errmsg = ex.Message;
                return sessionResult;
            }
        }


        public CustomSession IdentifySession()
        {
            CustomSession sessionResult = new CustomSession();

                    sessionResult.Company = "GOSHU";
                    sessionResult.CompanyName = "Goshu.co.th";
                    sessionResult.PlantId = "MfgSys";
                    sessionResult.PlantName = "Main Plant";
                    sessionResult.UserId = "manager";
                    sessionResult.Username = "manager";
                    sessionResult.SessionId = "xxxxxx";
                    sessionResult.Client = "localhost";
                    sessionResult.Password = "manager";
                

                return sessionResult;               
                    }
    }
}