﻿using System;
using System.Collections.Generic;


namespace MPAG_OrderAndTrip
{
    /**
    * \brief   The Order class contains all the information relating to the delivery of a customer's goods
    * \details The Order defines all information for the realization of a shipment. It contains the type of delivery (FTL or LTL), quantity,
    *          origin, destination and van type (Dry or Reefer). This information, that will be grabbed from the contract marketplace, plus
    *          date information and trips necessary to accomplish a order.
    */
    public class Order : IOrderCreation
    {
        // Constants
        // Debug: Access the database to get the Valid Cities
        private static readonly List<string> ValidCities = new List<string> { "Toronto", "Waterloo", "Windsor", "London" };  

        //--------- Attributes ---------//
        public int orderID { get; set; }

        private string _origin;
        public string origin
        {
            get { return _origin; }
            set
            {
                if(!ValidateCity(value))
                {
                    throw new Exception ("Invalid City -- The city needs to be member of the ValidCities list");
                }

                _origin = value;
            }
        }

        private string _destination;
        public string destination
        {
            get { return _destination; }
            set
            {
                if (!ValidateCity(value))
                {
                    throw new Exception("Invalid City -- The city needs to be member of the ValidCities list");
                }

                _destination = value;
            }
        }

        public int status { get; set; }
        public uint quantity { get; set; }
        public bool jobType { get; set; }           
        public bool vanType { get; set; }
        public DateTime dateCreated { get; set; }
        public List<Trip> assignedTrips = null;         // How do I attribute visibility to Collections
        public DateTime dateCompleted { get; set; }


        //--------- Methods ---------//
        /// <summary>
        /// Static method to validate the city to make sure the city is included in the database
        /// </summary>
        /// <param name="newCity"> <b>string</b> - city that is going to be validated </param>
        /// <returns>Returns true if city is valid, false otherwise</returns>
        private static bool ValidateCity(string newCity)
        {
            bool isValid = false;

            foreach (string city in ValidCities)
            {
                if(newCity == city)
                {
                    isValid = true;
                    break;
                }
            }

            return isValid;
        }

        /// <summary>
        /// Default constructor. the dummy order object is used to get access to the database.
        /// </summary>
        public Order()
        {

        }

        /// <summary>
        /// Constructor for the Order class. It requires the job type (FTL or LTL), the relevant cities (origin and destination), and the van type (Refrigirated or Dry) 
        /// </summary>
        /// <param name="jobType"> <b>bool</b> - True if tht job type is LTL, false if it is FTL </param>
        /// <param name="quantity"> <b>uint</b> - Represents the number of pallets in a order. 0 if it is a FTL, positive integer representing pallets otherwise </param>
        /// <param name="origin"> <b>string</b> - City origin of the order </param>
        /// <param name="destination"> <b>string</b> - City destination, where the cargo will be unloaded </param>
        /// <param name="vanType"> <b>bool</b> - True if the cargo load is Reefer, false if it is Dry </param>
        public Order(bool jobType, uint quantity, string origin, string destination, bool vanType)
        {
            Random rng = new Random();          // DEBUG: This is a placeholder for the orderId that will
            orderID = rng.Next(10000, 99000);   // be grabbed from the database baased on the Id of the last order

            if (jobType && quantity == 0)
            {
                throw new Exception("A LTL Job needs to have at least one pallet");
            }

            this.jobType = jobType;
            this.quantity = quantity;
            this.vanType = vanType;
            this.origin = origin;
            this.destination = destination;
            dateCreated = DateTime.Now;
        }

        /// <summary>
        /// Wrapper method for the constructor that servers as the implementation of the IOrderCreation interface. 
        /// It requires the job type (FTL or LTL), the relevant cities (origin and destination), and the van type (Refrigirated or Dry)
        /// </summary>
        /// <param name="jobType"> <b>bool</b> - True if tht job type is LTL, false if it is FTL </param>
        /// <param name="quantity"> <b>uint</b> - Represents the number of pallets in a order. 0 if it is a FTL, positive integer representing pallets otherwise </param>
        /// <param name="origin"> <b>string</b> - City origin of the order </param>
        /// <param name="destination"> <b>string</b> - City destination, where the cargo will be unloaded </param>
        /// <param name="vanType"> <b>bool</b> - True if the cargo load is Reefer, false if it is Dry </param>
        /// <returns>Returns the order with the information provided by the parameters (if valid)</returns>
        public Order CreateOrder(bool jobType, uint quantity, string origin, string destination, bool vanType)
        {
            Order newOrder = new Order(jobType, quantity, origin, destination, vanType);
            return newOrder;
        }

        /// <summary>
        /// Used to add the calling order to the TMS database, using Data access layer
        /// </summary>
        public void AddOrder()
        {
            new TMSDAL().InsertOrder(this);
        }

        /// <summary>
        /// Used to confirm the order in the TMS database, using Data access layer
        /// </summary>
        public void confirmOrder()
        {
            new TMSDAL().confirmOrder(this);
        }


    }
}
