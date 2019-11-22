using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAG_OrderAndTrip
{
    /**
    * \brief    The WaitingTruck class represents an truck that is waiting for more orders to leave its depot.
    * \details  The WaitingTruck class serves to accomodate more LTL orders in a single truck. The truck will have a time to leave variable which 
    *           is instantiated after the first LTL order is attributed a trip. Doing that allows a buffer before the truck leaves so that more orders
    *           can be assigned to that truck.
    * \see Depot, Order, Trip 
    */
    public class WaitingTruck
    {
        List<Order> AwaitingOrders = null;
        DateTime TimeToLeave;
        uint quantityPallets;

        /// <summary>
        /// Constructor for the WaitingTruck. It required the first orders attributed that truck and the delay (in hours)
        /// that is added to the current time determing when the truck will leave
        /// </summary>
        /// <param name="orders"> <b>List<Order></b> - the first orders attributed to that truck </param>
        /// <param name="delayInHours"> <b>int</b> - the amount of hours that an outside orders has to assign that truck </param>
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
