using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAG_OrderAndTrip
{
    public class Depot
    {
        string location;
        private int availibleFTL;
        private int avalibleLTL;
        public List<Trip> Trips;
       
        public Depot(string city, int initialFTLs, int initialLTLs)
        {
            location = city;
            availibleFTL = initialFTLs;
            avalibleLTL = initialLTLs;
        }
    }
}
