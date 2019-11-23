using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAG_OrderAndTrip
{
    public class Address
    {
        public string streetAddress { get; set; }
        public string city { get; set; }
        public  string province { get; set; }
        public string postalCode { get; set; }

        public Address(string street, string cityName, string provinceName, string postal)
        {
            streetAddress = street;
            city = cityName;
            province = provinceName;
            postalCode = postal;
        }
    }
}
