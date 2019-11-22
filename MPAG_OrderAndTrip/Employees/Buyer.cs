﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAG_OrderAndTrip
{
     /** \class
     * \brief Class used to represent a buyer.
     * \details Inherits from the employee class and implements methods from IOrderCreation interface class.
     * Buyer can create orders and track a list of orders. 
     * \see Employee
     *
     */
    public class Buyer : Employee, IOrderCreation
    {
        private List<Order> CreatedOrders;

        /// <summary>
        /// This constructor is used to instantiate a Buyer with the specified field values
        /// </summary>
        /// <para name="firstName"> <b>string</b> - Buyer first name</param>
        /// <para name="lastName"> <b>string</b> - Buyer last name</param>
        /// <para name="email"> <b>string</b> - Buyer email</param>
        /// <para name="phoneNum"> <b>string</b> - Buyer phone number</param>
        /// <para name="streetAddress"> <b>string</b> - Buyer street address</param>
        /// <para name="city"> <b>string</b> - Buyer's city</param>
        /// <para name="province"> <b>string</b> - Buyer's province</param>
        /// <para name="postalCode"> <b>string</b> - Buyer's postal code</param> 
        public Buyer
            (string firstName, string lastName, string email, string phoneNum, 
            string streetAddress, string city, string province, string postalCode) : 
            base("Buyer", firstName, lastName, email, phoneNum, streetAddress, city, province, postalCode)
        {
            CreatedOrders = new List<Order>();
        }

        /// <summary>
        /// This method is used to Create a new order given specified values
        /// </summary>
        /// <param name="jobType"> <b>bool</b> - Order job type(LTL or FTL)</param>
        /// <param name="quantity"> <b>unint</b> - Quantity of the job</param>
        /// <param name="origin"> <b>string</b> - Where the order will be shipped from</param>
        /// <param name="destination"> <b>string</b> - Where the order will be shipped to/param>
        /// <param name="vanType"> <b>bool</b> - Van type:dry or reefer</param>

        /// \see Order 
        public Order CreateOrder(bool jobType, uint quantity, string origin, string destination, bool vanType)
        {
            Order newOrder = new Order(jobType, quantity, origin, destination, vanType);
            CreatedOrders.Add(newOrder);      // Attribute the Order to the buyer
            return newOrder;
        }
    }
}
