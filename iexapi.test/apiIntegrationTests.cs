using System;
using NUnit.Framework;
using iexapi;
using iexapi.Models;

namespace iexapi.test
{
    [TestFixture]
    public class ApiIntegrationTests : TestSetup
    {
        [Test]
        public void CanGetPriceHistory()
        {
            var prices = api.GetPriceHistory("aapl", "1m");
            Assert.Less(0, prices.Count);
        }

        [Test]
        public void CanGetStockReferenceData()
        {
            var stats = api.GetAdvancedStats("aapl");
            Assert.AreEqual("AAPL", stats.Symbol);
        }
    }
}
