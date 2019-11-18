using System;
using System.Collections.Generic;


namespace MPAG_OrderAndTrip
{
    class Carrier
    {
        public int carrierId { get; set; }
        public string carrierName { get; set; }
        private List<string> DepotCities = null;   // How to access a list??
        private int availibleFTL;
        private int avalibleLTL;
        private double FTLRate;
        private double LTLRate;
        private double ReeferCharge;
        public string Phone { get; set; }
        public string Email { get; set; }

        // Temporary Constructor: the Carrier should only be created by the Admin Class -> Implement interface AdminRoles:CreateCarrier
        public Carrier(string name, int initialAvaFTL, int initialAvaLTL, double rateFTL, double rateLTL, double charge, List<string> initialDepots)
        {
            Random rng = new Random();            // DEBUG: This is a placeholder for the CarrierId that will
            carrierId = rng.Next(10000, 99000);   // be grabbed from the database baased on the Id of the last order

            //-----------------------PART of the ADMIN ROLE------------------------------------------------//
            carrierName = name;
            availibleFTL = initialAvaFTL;
            avalibleLTL = initialAvaLTL;
            FTLRate = rateFTL;
            LTLRate = rateLTL;
            ReeferCharge = charge;

            DepotCities = initialDepots;   // The admin will list the availible cities for that carrier
        }

        public Carrier()
        {
        }

        public void ChangeFTLRate(Carrier someCarrier, double newFTLRate)
        {
            if(newFTLRate > 0.00)
            {
                someCarrier.FTLRate = newFTLRate;
            }
        }

        public void ChangeLTLRate(Carrier someCarrier, double newLTLRate)
        {
            if (newLTLRate > 0.00)
            {
                someCarrier.LTLRate = newLTLRate;
            }
        }

        public List<Carrier> getCarriersWithDepot()
        {
            var carriers = new TMSDAL().GetCarriers(this);
            return carriers;
        }
    }
}
