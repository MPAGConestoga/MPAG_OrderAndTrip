
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
            /*Order newOrder = null;

            Buyer buyer1 = new Buyer("Mark", "Ruffalo", "test@gmail.com", "SomeAddress", "9003930");
            try
            {
              buyer1.CreateOrder(true, 10, "Toronto", "Waterloo", true);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);               //---------------DEBUG---------------------//
            }
            newOrder.AddOrder();
            newOrder.confirmOrder();

            Console.WriteLine(newOrder.origin);
            Console.WriteLine(newOrder.destination);
            Console.WriteLine(newOrder.jobType);
            Console.WriteLine(newOrder.vanType);*/

            //Person bob = new Person("John", "Wick", "@gmail.com", "gogoaddress", "123");
            //int i = new TMSDAL().SearchForCustomer(bob);
            //Console.WriteLine(i);

            //Carrier test = new Carrier();
            //test.carrierName = "Carrier 1";
            var list = new TMSDAL().GetCarriersByCity("Guelph");
            Console.WriteLine("");
            

        }
    }
}
