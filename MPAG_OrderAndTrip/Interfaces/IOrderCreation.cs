using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAG_OrderAndTrip
{
    /// <summary>
    /// Defines the methods that the Buyer class is responsible to implement and are included in Order
    /// \see Buyer
    /// </summary>
    interface IOrderCreation
    {
        Order CreateOrder(bool jobType, uint quantity, string origin, string destination, bool vanType);
    }
}
