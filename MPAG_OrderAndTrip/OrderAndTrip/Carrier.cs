using System;
using System.Collections.Generic;


namespace MPAG_OrderAndTrip
{
    class Carrier
    {
        // ---------- Attributes ---------------//
        // Contact information
        public int carrierId { get; set; }
        public string carrierName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
            
        // Business Information
        public Dictionary<string, Depot> CityDepots = null;             // Key can be city ID???
        private double FTLRate;
        private double LTLRate;
        private double ReeferCharge;


        // ---------- Constructors ---------------//
        // Temporary Constructor: the Carrier should only be created by the Admin Class -> Implement interface AdminRoles:CreateCarrier
        public Carrier(string name, double rateFTL, double rateLTL, double charge, Dictionary<string, Depot> initialDepots)
        {
            Random rng = new Random();            // DEBUG: This is a placeholder for the CarrierId that will
            carrierId = rng.Next(10000, 99000);   // be grabbed from the database baased on the Id of the last order

            //-----------------------PART of the ADMIN ROLE------------------------------------------------//
            carrierName = name;
            FTLRate = rateFTL;
            LTLRate = rateLTL;
            ReeferCharge = charge;

            CityDepots = initialDepots;   // The admin will list the availible cities for that carrier
        }

        public Carrier()
        {
        }

        // ---------- Methods---------------//
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
            //need to change method below. should be carrierbycity
            var carriers = new TMSDAL().GetCarrierByName(this);
            return carriers;
        }
    }
}
