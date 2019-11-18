using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAG_OrderAndTrip
{
    class Planner : Employee
    {
        public Planner(string firstName, string lastName, string email, string address, string phoneNum = "NA") :
            base("Planner", firstName, lastName, email, address, phoneNum)
        { }

        //---------------Methods-----------------------//
        //public List<Carrier> GetRelevantCarriers(Order pendingOrder)
        //{
        //    // Instatiate Data access layer 
        //    // Call method pass(pendingOrder.orgin)j
        //    foreach()

        //    pendingOrder.origin
        //}
    }
}
