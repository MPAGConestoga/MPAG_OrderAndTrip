using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MPAG_OrderAndTrip;

namespace Milestone03_Marketplace.Employees
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class EmployeeTest
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
        public void TestEmployeeRole()
        {
            Employee TestEmployee = new Employee("Buyer", "Gabriel", "Gurgel", "gabsatan@gmail.com", "9230929923",
                "Wdaasddasd", "MegatonTown", "Kitchener", "N2E3E");

        }


        [TestMethod]
        public void TestEmployeeRoleFail()
        {
            Employee TestEmployee = new Employee("DoofusRole", "Gabriel", "Gurgel", "gabsatan@gmail.com", "9230929923",
                "Wdaasddasd", "MegatonTown", "Kitchener", "N2E3E");
                      
        }
    }
}
