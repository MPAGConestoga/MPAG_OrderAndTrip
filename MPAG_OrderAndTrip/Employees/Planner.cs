using System;
using System.Collections.Generic;

namespace MPAG_OrderAndTrip
{
    /**
    * \brief   The Planner class represents the planner role in the TMS.
    * \details The Planner is the one responsible for assigning a Carriers to Order and for tracking the completion of an Order 
    */
    class Planner : Employee
    {
        /// <summary>
        /// Constructor for the Planner. It requires their role name ,first, last name, email, phone number and address
        /// </summary>
        /// <param name="role"> <b>string</b> - Name of the role </param>
        /// <param name="firstName"> <b>string</b> - Employee's first name</param>
        /// <param name="lastName"> <b>string</b> - Employee's last name</param>
        /// <param name="email"> <b>string</b> - Employee's email</param>
        /// <param name="phoneNum"> <b>string</b> - Employee's phone number</param>
        /// <param name="streetAddress"> <b>string</b> - Part of the Address object that will be generated</param>
        /// <param name="city"> <b>string</b> - Part of the Address object that will be generated</param>
        /// <param name="province"> <b>string</b> - Part of the Address object that will be generated</param>
        /// <param name="postalCode"> <b>string</b> - Part of the Address object that will be generated</param>
        public Planner
           (string firstName, string lastName, string email, string phoneNum,
           string streetAddress, string city, string province, string postalCode) :
           base("Planner", firstName, lastName, email, phoneNum, streetAddress, city, province, postalCode)
        { }

        //---------------Methods-----------------------//
        /// <summary>
        /// Gets Carriers that have a Depot in the order's origin city 
        /// </summary>
        /// <param name="origin"> <b>string</b> - Order's origin city </param>
        /// <returns>Returns the List of all relevant carriers that can accomplish a particular order </returns>
        public List<Carrier> GetRelevantCarriers(string origin)
        {
            // Stubbed Out code -----IMPLEMENT -----------------------//
            // -> Waiting for Data Acess Layer for the Relevant Cities
            Dictionary<string, Depot> tempDepotCities = new Dictionary<string, Depot>
            {
                {"Toronto", new Depot("Toronto", 10, 5) },
                { "Waterloo", new Depot("Waterloo", 20, 10) },
                { "Windsor", new Depot("Windsor", 9, 6) }
            };

            Carrier possCarrier1 = new Carrier("UberCarrier", 5.00, 3.00, 100.00, tempDepotCities);
            Carrier possCarrier2 = new Carrier("Damn Delivery", 5.00, 3.00, 100.00, tempDepotCities);
            Carrier possCarrier3 = new Carrier("Wee Delivery", 5.00, 3.00, 100.00, tempDepotCities);
            Carrier possCarrier4 = new Carrier("OutOfIdeas", 5.00, 3.00, 100.00, tempDepotCities);

            List<Carrier> possibleCarriers = new List<Carrier> { possCarrier1, possCarrier2, possCarrier3, possCarrier4 };
            return possibleCarriers;
        }

        public bool SelectCarriers(List<Carrier> SelectedCarriers, Order pendingOrder)
        {
            // Stubbed Out ----------------------- IMPLEMENT -----------------------//
            return true;
        }

        public void ChangeOrderSpeedTime(Order activeOrder, int daysToAdvance)
        {
            // Stubbed Out ----------------------- IMPLEMENT -----------------------// 
        }

        public bool ConfirmOrderCompletion(Order activeOrder)
        {
            // Stubbed Out ----------------------- IMPLEMENT -----------------------//
            return true;
        }

        public List<Invoice> ShowInvoiceSummary(Enum selectTime)
        {
            // Stubbed Out ----------------------- IMPLEMENT -----------------------//
            List<Invoice> SummaryInvoice = new List<Invoice>();
            return SummaryInvoice;
        }
    }
}
