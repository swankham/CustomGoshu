using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Erp.Custom.CostManagement;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Erp.Custom.CostManagement.Models;
namespace Erp.Custom.CostManagement.Repositories.Tests
{
    [TestClass()]
    public class RepositoriesTests
    {
        private readonly IEstimate _repo;

        public RepositoriesTests()
        {
            //this._repo = new Repositories();
        }

        [TestMethod()]
        public void GetLastRunningTest()
        {
            EstimateRunningModel model = new EstimateRunningModel();
            //model = _repo.GetLastRunning("PD");
            var rs = model.Company;
            Assert.Fail();
        }
    }
}
