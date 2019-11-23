using System;
using MPAG_OrderAndTrip;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Milestone03_Marketplace
{
    [TestClass]
    public class TMSTest
    {
        [TestMethod]
        public void TestConnectionToDatabase()
        {
            Person bob = new Person("John", "Wick", "@gmail.com", "123", "gogoaddress", "t", "t", "t");
            bob.GetPersonInfo();

        }

        [TestMethod]
        public void TestRetrievalFromDatabase()
        {
            Order test = new Order(false, 20, "Toronto", "Waterloo", false);
            test.AddOrder();
        }
        [TestMethod]

        public void TestInsertion()
        {
            Person john = new Person("John", "Wick", "@gmail.com", "123", "gogoaddress", "t", "t", "t");
            john.GetPersonInfo();

        }
        [TestMethod]

        public void TestRetrievalMultipleValues()
        {
            Carrier test = new Carrier();
            test.carrierName = "Carrier 1";
            var list = new TMSDAL().GetCarriersByCity("Guelph");
        }
    }
}
