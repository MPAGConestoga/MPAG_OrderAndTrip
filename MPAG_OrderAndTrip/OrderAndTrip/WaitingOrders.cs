using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAG_OrderAndTrip
{

    public class WaitingOrders
    {
        List<Order> AwaitingOrders = null;
        DateTime TimeToLeave;
        uint quantityPallets;
        uint direction;

        public WaitingOrders(Order firstOrder, double delayInHours)
        {
            // Attribute first order to the list of awating orders 
            AwaitingOrders.Add(firstOrder);

            // Set the time the truck leaves (Current Time + Delay)
            TimeToLeave = DateTime.Now;
            TimeToLeave.AddHours(delayInHours);

            quantityPallets = firstOrder.quantity;
        }
    }
}
