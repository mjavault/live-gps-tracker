using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveGpsTracking
{
    class Position
    {
        private static double R = 6371.0;
        public double Latitude;
        public double Longitude;
        public double Altitude;
        public double Accuracy;

        public Position()
        {
        }

        public Position(double lat, double lon)
        {
            Latitude = lat;
            Longitude = lon;
        }

        public Position(double lat, double lon, double alt)
        {
            Latitude = lat;
            Longitude = lon;
            Altitude = alt;
        }
        
        public Position(double lat, double lon, double alt, double accuracy)
        {
            Latitude = lat;
            Longitude = lon;
            Altitude = alt;
            Accuracy = Accuracy;
        }

        public override string ToString()
        {
            return Latitude + "," + Longitude + "," + Altitude;
        }

        public double distanceTo(Position other)
        {
            if (other != null)
            {
                double dLat = deg2rad(other.Latitude - Latitude);
                double dLon = deg2rad(other.Longitude - Longitude);
                double lat1 = deg2rad(Latitude);
                double lat2 = deg2rad(other.Latitude);

                double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                        Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(lat1) * Math.Cos(lat2);
                double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
                double d = R * c;
                return (d * 1000);
            }
            else
            {
                return 0;
            }
        }

        double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        double rad2deg(double rad)
        {
            return (rad * 180.0 / Math.PI);
        }
    }
}
