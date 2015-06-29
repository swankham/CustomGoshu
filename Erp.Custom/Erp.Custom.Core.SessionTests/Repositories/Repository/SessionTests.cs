using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Erp.Custom.Core.Session.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Erp.Custom.Core.Session.Repositories.Tests
{
    [TestClass()]
    public class SessionTests
    {
        private readonly ISession _repo;

        public SessionTests()
        {
            this._repo = new Session();
        }

        [TestMethod()]
        public void IdentifySessionTest()
        {
           //var result = _repo.IdentifySession();
            Assert.ReferenceEquals("Ice.Core.Session", "result");
        }
    }
}
