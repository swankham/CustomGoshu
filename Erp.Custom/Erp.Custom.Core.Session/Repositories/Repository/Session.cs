using Erp.Custom.Core.Session.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace Erp.Custom.Core.Session.Repositories
{
    public class Session : ISession
    {
        private string configurationPath;
        private XmlDocument configurationDocument;

        public CustomSession IdentifySession(string userName, string userPassword, out string errmsg)
        {
            errmsg = "";
            CustomSession sessionResult = new CustomSession();
            String[] arguments = Environment.GetCommandLineArgs();

            var result = ProcessCommandLineArguments(arguments);
            sessionResult.AppServerURL = result.FirstOrDefault(x => x.Key.Equals("AppServerURL")).Value;
            sessionResult.ConnectionString = result.FirstOrDefault(x => x.Key.Equals("connectionString")).Value;
            sessionResult.UserId = result.FirstOrDefault(x => x.Key.Equals("UserID")).Value;
            sessionResult.Password = result.FirstOrDefault(x => x.Key.Equals("Password")).Value;

            if (!string.IsNullOrEmpty(sessionResult.UserId) && !string.IsNullOrEmpty(sessionResult.Password))
            {
                userName = sessionResult.UserId;
                userPassword = sessionResult.Password;
            }

            try
            {
                Ice.Core.Session curr = new Ice.Core.Session(userName, userPassword
                                        , sessionResult.AppServerURL
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

        //public CustomSession IdentifySession(out string errmsg = "")
        //{
        //    CustomSession sessionResult = new CustomSession();

        //    sessionResult.Company = "GOSHU";
        //    sessionResult.CompanyName = "Goshu.co.th";
        //    sessionResult.PlantId = "MfgSys";
        //    sessionResult.PlantName = "Main Plant";
        //    sessionResult.UserId = "manager";
        //    sessionResult.Username = "manager";
        //    sessionResult.SessionId = "xxxxxx";
        //    sessionResult.Client = "localhost";
        //    sessionResult.Password = "manager";

        //    return sessionResult;
        //}

        public Dictionary<string, string> ProcessCommandLineArguments(string[] args)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            this.configurationDocument = new XmlDocument();
            this.configurationPath = Directory.GetCurrentDirectory() + @"\config";

            foreach (string str in args)
            {
                if (str.StartsWith("/config=", StringComparison.OrdinalIgnoreCase) || str.StartsWith("-config=", StringComparison.OrdinalIgnoreCase))
                {
                    configurationPath = str.Substring(str.IndexOf('=') + 1);
                    if (Path.GetDirectoryName(configurationPath) != "")
                    {
                        if (!File.Exists(configurationPath))
                        {
                            return result;
                        }
                    }
                    else
                    {
                        string path = Directory.GetCurrentDirectory() + @"\" + configurationPath;
                        if (!File.Exists(path))
                        {
                            if (!File.Exists(Directory.GetCurrentDirectory() + @"\config\" + configurationPath))
                            {
                                return result;
                            }
                            configurationPath = Directory.GetCurrentDirectory() + @"\config\" + configurationPath;
                        }
                        else
                        {
                            configurationPath = path;
                        }
                    }
                }
            }
            this.configurationDocument.Load(configurationPath);

            Dictionary<string, string> dict1 = new Dictionary<string, string>();
            Dictionary<string, string> dict2 = new Dictionary<string, string>();

            XmlNode node1 = this.configurationDocument.SelectSingleNode("//appSettings");
            dict1 = AttributeBinding(node1);

            XmlNode node2 = this.configurationDocument.SelectSingleNode("//userSettings");
            dict2 = AttributeBinding(node2);

            result = dict1.Union(dict2).ToDictionary(x => x.Key, x => x.Value);
            return result;
        }

        private Dictionary<string, string> AttributeBinding(XmlNode _root)
        {
            Dictionary<string, string> attr = new Dictionary<string, string>();

            foreach (XmlNode node in _root.ChildNodes)
            {
                if (node.GetType() != typeof(XmlComment))
                {
                    attr.Add(node.Name, node.Attributes["value"].Value);
                }
            }

            return attr;
        }

        public Ice.Core.Session GetSession()
        {
            CustomSession sessionResult = new CustomSession();
            sessionResult.AppServerURL = "net.tcp://GOLLUM/E10Pilot";
            sessionResult.ConnectionString = "Data Source=gollum;Initial Catalog=E10Pilot;Persist Security Info=True;User ID=sa;Password=sp3@rm1nt";
            sessionResult.UserId = "manager";
            sessionResult.Password = "manager";

            try
            {
                Ice.Core.Session curr = new Ice.Core.Session("manager", "manager"
                                        , "net.tcp://GOLLUM/E10Pilot"
                                        , Ice.Core.Session.LicenseType.Default);
                return curr;
            }
            catch
            {
                return null;
            }
        }


        public CustomSession GetSessionForWCFAccount()
        {
            CustomSession sessionResult = new CustomSession();
            String[] arguments = Environment.GetCommandLineArgs();

            var result = ProcessCommandLineArguments(arguments);
            sessionResult.UserId = result.FirstOrDefault(x => x.Key.Equals("ActiveServcieWCFUser")).Value;
            sessionResult.Password = result.FirstOrDefault(x => x.Key.Equals("ActiveServcieWCFPassword")).Value;

            return sessionResult;
        }
    }
}