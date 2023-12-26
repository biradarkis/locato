using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locato.Data.Web
{
    [ComplexType]
    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }

        public bool MatchByRadius(Location target, double radius)
        {
            // One degree of latitude is equal to about 69 or 70 miles or 111 Km.
            // For more detail please refer this link http://www.techraza.com/other/search-around-a-particular-latitude-and-longitude-by-a-given-radius/

            var latRadius = radius / 111;
            var minLat = Latitude - latRadius;
            var maxLat = Latitude + latRadius;
            var minLong = Longitude - latRadius;
            var maxLong = Longitude + latRadius;

            return (target.Latitude >= minLat && target.Latitude <= maxLat) && (target.Longitude >= minLong && target.Longitude <= maxLong);
        }

        public override string ToString()
        {
            var locationText = string.Empty;

            if (!string.IsNullOrEmpty(Street))
                locationText = Street + ", ";

            if (!string.IsNullOrEmpty(City))
                locationText += City + ", ";

            if (!string.IsNullOrEmpty(State))
                locationText += State + ", ";

            if (!string.IsNullOrEmpty(Country))
                locationText += Country + ", ";

            if (!string.IsNullOrEmpty(Zip))
                locationText += Zip + ", ";

            return locationText.TrimEnd(',', ' ');
        }
    }
}
