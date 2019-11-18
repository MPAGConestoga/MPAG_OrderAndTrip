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

        // Constructor 
        public Buyer(string firstName, string lastName, string email, string address, string phoneNum = "NA") : 
            base("Buyer", firstName, lastName, email, address, phoneNum)
        {
            CreatedOrders = new List<Order>();
        }

        // Methods 
        // Create Order 
        public Order CreateOrder(bool jobType, uint quantity, string origin, string destination, bool vanType)
        {
            Order newOrder = new Order(jobType, quantity, origin, destination, vanType);
            CreatedOrders.Add(newOrder);      // Attribute the Order to the buyer
            return newOrder;
        }
    }
}
