using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Tests
{
    [TestClass()]
    public class GroceryListApiTests
    {
        [TestMethod()]
        public async Task GetListFromIdTest()
        {
            var service = new GroceryListApi();
            var obj = await service.GetListFromId(1);

            Assert.IsNotNull(obj);
        }
    }
}