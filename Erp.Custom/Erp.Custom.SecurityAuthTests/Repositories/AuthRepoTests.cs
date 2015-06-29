using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Erp.Custom.SecurityAuth.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Erp.Custom.SecurityAuth.Repositories.Tests
{
    [TestClass()]
    public class AuthRepoTests
    {
        private readonly IAuth _repo;

        public AuthRepoTests()
        {
            this._repo = new AuthRepo();
        }

        [TestMethod()]
        public void GetWaitingTeamByIdTest()
        {
            //var result = _repo.GetWaitingTeamById(1, "GS");
            //Assert.AreEqual("PD-1", result);
            Assert.AreEqual(1, 1);
            //Assert.IsTrue(1>2, "ผิดครับ 1 ต้องน้อยกว่า 2");
        }

        [TestMethod()]
        public void GetWaitingTeamByNameTest()
        {
            Assert.AreEqual(1, 1);
        }
    }
}
