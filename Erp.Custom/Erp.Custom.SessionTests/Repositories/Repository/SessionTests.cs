using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Erp.Custom.Session.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Erp.Custom.Session.Models;
namespace Erp.Custom.Session.Repositories.Tests
{
    [TestClass()]
    public class SessionTests
    {
        private readonly ISession _repo;

        public SessionTests()
        {
            _repo = new Session();
        }


        [TestMethod()]
        public void IdentifySessionTest()
        {
            string errmsg = string.Empty;

            // Act
            var result = _repo.IdentifySession("manager", "manager", out errmsg);

            // Assert
            Assert.AreEqual("Erp.Custom.Session.Models.CustomSession", result.GetType().ToString());
        }
    }
}
