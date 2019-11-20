
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
            // TEST FOR THE FULL WORKFLOW OF BUYER AND PLANNER      
            
            // BUYER WORKFLOW
            // Creating Buyer
            Buyer empBuyer = new Buyer("John", "Wick", "johnWickWhatever@gmail.com", "555789849", 
                                       "DamnStreet", "Waterloo", "Ontario", "N2E6D0");

            // Buyer got info from contract marketplace, now they are creating order to submit to planner 
            Order newOrder = empBuyer.CreateOrder(true, 10, "Toronto", "Waterloo", false);

            // PLACEHOLDER: Send to the database -> will set status to [PENDING]

            // PLANNER WORKFLOW
            // Create Planner
            Planner empPlanner = new Planner("Ulfric", "Stormcloack", "freeSkyrim@uol.com", "555789849",
                           "DamnStreet", "Waterloo", "Ontario", "N2E6D0");

            // Get list of relevant cities
            List<Carrier> relevantCarriers = new List<Carrier> (empPlanner.GetRelevantCarriers(newOrder.origin));

            // Select Carrier 
            


        }
    }
}
