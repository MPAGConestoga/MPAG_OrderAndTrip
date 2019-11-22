using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BuyerAccessToMarketplace;

namespace Milestone03_Marketplace
{
    [TestClass]
    public class MarketplaceAccessTest
    {
        [TestMethod]
        public void PullNumberRead()
        {
            string testValue = "4";
            bool result = false;
            BuyerAccessToMarketplace.MarketplaceAccess obj = new BuyerAccessToMarketplace.MarketplaceAccess();
            result = obj.IsDigitOnly(testValue);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void CheckFalseValue()
        {
            string testValue = "4h5";
            BuyerAccessToMarketplace.MarketplaceAccess obj = new BuyerAccessToMarketplace.MarketplaceAccess();
            bool result = obj.IsDigitOnly(testValue);
            Assert.AreEqual(false, result);          
        }
    }
}
