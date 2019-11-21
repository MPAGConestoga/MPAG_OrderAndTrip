using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAG_OrderAndTrip
{
    public class WaitingTruck
    {
        List<Order> AwaitingOrders = null;
        DateTime TimeToLeave;
        uint quantityPallets;

        public WaitingTruck(List<Order> orders, double delayInHours)
        {
            // Attribute Orders that are waiting for the Trip
            AwaitingOrders = orders;

            // Set the time the truck leaves (Current Time + Delay -> Determined by Carrier)
            TimeToLeave = DateTime.Now;
            TimeToLeave.AddHours(delayInHours);

            // Set number of pallets for that truck
            foreach(Order order in AwaitingOrders)
            {
                quantityPallets += order.quantity;
            }
        }

        // Check if TimetoLeave is equal to Time Now OR Quantity is equal to maxValue
    }
}
