using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MPAG_OrderAndTrip;

namespace Milestone03_Marketplace
{
    /// <summary>
    /// Summary description for OrderTest
    /// </summary>
    [TestClass]
    public class OrderTest
    {
        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestOrderCreation()
        {
            Buyer buyer1 = new Buyer("Gabriel", "WantsToDie", "gabsantana@gmail.com", "3434434334",
                "AddressStreet", "Waterloo", "Ontario", "N2E2E2");

            Order testOrder = buyer1.CreateOrder(true, 10, "Waterloo", "Toronto", false);
        }

        [TestMethod]
        public void TestOrderCreationFail()
        {
            Buyer buyer1 = new Buyer("Gabriel", "WantsToDie", "gabsantana@gmail.com", "3434434334",
            "AddressStreet", "Waterloo", "Ontario", "N2E2E2");

            Order testOrder = buyer1.CreateOrder(true, 10, "WOOW", "Toronto", false);
        }
    }
}
