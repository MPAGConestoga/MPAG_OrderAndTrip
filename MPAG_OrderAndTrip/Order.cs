using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAG_OrderAndTrip
{
    public class Order : IOrderCreation
    {
        //--------- Attributes ---------//
        public readonly int orderID;

        private string _origin;
        private string _destination;
        private static readonly List<string> ValidCities =    //----DEBUG:
            new List<string> {"Toronto", "Waterloo"};         // Access the database to get the Valid Cities
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
        public DateTime dateCompleted { get; set; }

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
            Random rng = new Random();
            orderID = rng.Next(10000, 99000);
        }
      
        public Order CreateOrder(bool jobType, uint quantity, string origin, string destination, bool vanType)
        {
            Order newOrder = new Order();
            return newOrder;
        }
    }
}
