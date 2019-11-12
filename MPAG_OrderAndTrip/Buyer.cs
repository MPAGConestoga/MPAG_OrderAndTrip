using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAG_OrderAndTrip
{
    public class Buyer : Employee, IOrderCreation
    {
        private List<Order> CreatedOrders;

        public Buyer(string firstName, string lastName, string email, string address, string phoneNum = "NA") : 
            base("Buyer", firstName, lastName, email, address, phoneNum)
        {
            CreatedOrders = new List<Order>();
        }

        public Order CreateOrder(bool jobType, uint quantity, string origin, string destination, bool vanType)
        {
            if (jobType && quantity == 0)
            {
                throw new Exception("A LTL Job needs to have at least one pallet");
            }

            Order newOrder = new Order();

            newOrder.jobType = jobType;
            newOrder.quantity = quantity;
            newOrder.vanType = vanType;
            newOrder.origin = origin;
            newOrder.destination = destination;
            newOrder.dateCompleted = DateTime.Now;

            // Attribute the Order to the buyer
            CreatedOrders.Add(newOrder);
            return newOrder;
        }
    }
}
