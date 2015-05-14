using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Erp.Custom.UI.Common.Repositories.Tests
{
    [TestClass()]
    public class CommonRepositoryTests
    {
        private readonly IMenu _repo;

        public CommonRepositoryTests()
        {
            _repo = new CommonRepository();
        }

        [TestMethod()]
        public void GetAllMenuTest()
        {
            // Act
            var result = _repo.GetAllMenu();
            var s = result.ToList().Count;
            // Assert
            Assert.IsFalse(s < 0);
        }
    }
}