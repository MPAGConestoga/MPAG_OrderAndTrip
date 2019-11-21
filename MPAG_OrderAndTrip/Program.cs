
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BuyerAccessToMarketplace;

namespace MPAG_OrderAndTrip
{
    class Program
    {
        static volatile bool Run = true;
        static void Main(string[] args)
        {

            // ------ TEST FOR THE FULL WORKFLOW OF BUYER AND PLANNER ---------- //    

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
            //bob.GetPersonInfo();
            //Console.WriteLine(i);

            //Carrier test = new Carrier();
            //test.carrierName = "Carrier 1";
            //var list = new TMSDAL().GetCarriersByCity("Guelph");
            //Console.WriteLine("");

            // --------------------------- CONTRACT MARKET PLACE PULL -------------------- //
            Console.WriteLine("{0,-20}\t{1,-10}\t{2,-10}\t{3,-15}\t{4,-15}\t{5,-10}",
                    "Client_Name",
                    "Job_Type",
                    "Quantity",
                    "Origin",
                    "Destination",
                    "Van_Type");
            //Start Thread
            Thread data = new Thread(new ThreadStart(MarketplaceAccess.Database));
            data.Start();

            //Stop data pull
            Console.ReadKey();
            Run = false;
            data.Join();

            //Quit console
            Console.WriteLine("Press key to quit console.");
            Console.ReadKey();

            // ------------------------------ BUYER WORKFLOW -----------------------------------//
            // Creating Buyer
            Buyer empBuyer = new Buyer("John", "Wick", "johnWickWhatever@gmail.com", "555789849", 
                                       "DamnStreet", "Waterloo", "Ontario", "N2E6D0");

            // Buyer got info from contract marketplace, now they are creating order to submit to planner 
            Order newOrder = empBuyer.CreateOrder(true, 10, "Toronto", "Waterloo", false);

            // PLACEHOLDER: Send to the database -> will set status to [PENDING]

            // ------------------------------ PLANNER WORKFLOW --------------------------------//
            // Create Planner
            Planner empPlanner = new Planner("Ulfric", "Stormcloack", "freeSkyrim@uol.com", "555789849",
                           "DamnStreet", "Waterloo", "Ontario", "N2E6D0");

            // Get list of relevant cities
            List<Carrier> relevantCarriers = new List<Carrier> (empPlanner.GetRelevantCarriers(newOrder.origin));

            // Select Carrier 
            


        }
    }
}
