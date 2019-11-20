using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAG_OrderAndTrip
{
    class Planner : Employee
    {
        public Planner
           (string firstName, string lastName, string email, string phoneNum,
           string streetAddress, string city, string province, string postalCode) :
           base("Planner", firstName, lastName, email, phoneNum, streetAddress, city, province, postalCode)
        { }

        //---------------Methods-----------------------//

        public List<Carrier> GetRelevantCarriers(string origin)
        {
            // Stubbed Out code -> Waiting for Data Acess Layer for the Relevant Cities
            Dictionary<string,Depot> tempDepotCities = new Dictionary<string, Depot>
            {
                {"Toronto", new Depot("Toronto", 10, 5) },
                { "Waterloo", new Depot("Waterloo", 20, 10) },
                { "Windsor", new Depot("Windsor", 9, 6) }
            };

            Carrier possCarrier1 = new Carrier("UberCarrier", 5.00, 3.00, 100.00, tempDepotCities);
            Carrier possCarrier2 = new Carrier("Damn Delivery", 5.00, 3.00, 100.00, tempDepotCities);
            Carrier possCarrier3 = new Carrier("Wee Delivery", 5.00, 3.00, 100.00, tempDepotCities);
            Carrier possCarrier4 = new Carrier("OutOfIdeas", 5.00, 3.00, 100.00, tempDepotCities);

            List<Carrier> possibleCarriers = new List<Carrier> { possCarrier1, possCarrier2, possCarrier3, possCarrier4 };
            return possibleCarriers;
        }

        public void SelectCarrier(int index, List<Carrier> possibleCarriers, Order pendingOrder)
        {
            Trip newTrip = new Trip(pendingOrder.origin, 10, 1000);
            pendingOrder.assignedTrips.Add(newTrip);

        }
    }
}
