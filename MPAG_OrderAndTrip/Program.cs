
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAG_OrderAndTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            Order newOrder = null;

            Buyer buyer1 = new Buyer("Mark", "Ruffalo", "test@gmail.com", "SomeAddress", "9003930");
            try
            {
                newOrder = buyer1.CreateOrder(true, 10, "Toronto", "Waterloo", true);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);               //---------------DEBUG---------------------//
            }

           

        }
    }
}
