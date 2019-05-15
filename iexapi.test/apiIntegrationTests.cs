using System;
using NUnit.Framework;
using iexapi;

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
    }
}