using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAG_OrderAndTrip
{
    public class Order : IOrderCreation
    {
        // Constants
        // Debug: Access the database to get the Valid Cities
        private static readonly List<string> ValidCities = new List<string> { "Toronto", "Waterloo" };  

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

        public Order()
        {

        }

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
      
        public Order CreateOrder(bool jobType, uint quantity, string origin, string destination, bool vanType)
        {
            Order newOrder = new Order(jobType, quantity, origin, destination, vanType);
            return newOrder;
        }

        public void AddOrder()
        {
            new TMSDAL().InsertOrder(this);
        }

        public void confirmOrder()
        {
            new TMSDAL().confirmOrder(this);
        }
    }
}
