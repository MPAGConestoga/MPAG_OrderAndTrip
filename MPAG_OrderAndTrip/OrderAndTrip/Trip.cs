using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAG_OrderAndTrip
{
    public class Trip
    {
        public string lastStop { get; set; }
        private int _addedHours;
        int addedHours
        {
            get { return _addedHours; }
            set
            {
                _addedHours += value;
            }
        }

        private double _addedKilometers;
        public double addedKilometers
        {
            get { return _addedKilometers; }
            set
            {
                _addedKilometers += value;
            }
        }

        public Trip(string initialStop, int initialHours, double initialKm)         // Km and hours should be self generated        
        {
            lastStop = initialStop;
            _addedHours = initialHours;
            _addedKilometers = initialKm;
        }
    }
}
