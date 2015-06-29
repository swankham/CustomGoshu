using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ice.CustomUI.PRList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Erp.Custom.Core.Session.Repositories;
namespace Ice.CustomUI.PRList.Tests
{
    [TestClass()]
    public class RequisitionRepoTests
    {
        private readonly IRequisition _repo;
        //private readonly ISession _ress;

        public RequisitionRepoTests()
        {
            this._repo = new RequisitionRepo();
            //this._ress = new Session();
        }

        [TestMethod()]
        public void GetStringTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SendToPOSuggestionsTest()
        {
            try
            {
                Ice.Core.Session curr = new Ice.Core.Session("manager", "manager", "net.tcp://GOLLUM/E10Pilot", Ice.Core.Session.LicenseType.Default);
            }
            catch (Exception ex)
            {
                goto x;
            }

            x:
            Assert.Fail();
        }
    }
}
