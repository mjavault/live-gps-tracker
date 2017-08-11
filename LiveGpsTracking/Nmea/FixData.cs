using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveGpsTracking.Nmea
{
    class FixData
    {
        public bool Valid = false;
        public double Latitude;
        public double Longitude;
        public double Altitude;
        public double Hdop;
        public DateTime Time;

        public static FixData Parse(String nmea)
        {
            //"$GPGGA,time%f,lat%f,latdir%c,lon%f,londir%c,quality%u,view%u,hdop%f,altitude%f"
            String[] items = nmea.Split(',');
            if (items.Length == 15)
            {
                int quality = Utils.ToInt(items[6]);
                if (quality > 0)
                {
                    FixData fix = new FixData();
                    //extract time value - but only if we didn't get a full date/time from another message
                    if (fix.Time < new DateTime(2, 1, 1))
                    {
                        fix.Time = new DateTime(
                            1,
                            1,
                            1,
                            Utils.ToInt(items[1].Substring(0, 2)),
                            Utils.ToInt(items[1].Substring(2, 2)),
                            Utils.ToInt(items[1].Substring(4, 2)),
                            DateTimeKind.Utc);
                    }

                    //convert latitude to decimal degrees format
                    double lat = Utils.ToDouble(items[2]);
                    if (items[3] == "S")
                    {
                        lat = -lat;
                    }
                    int latDegrees = (int)(lat / 100);
                    double latMinutes = (double)(lat - latDegrees * 100);
                    fix.Latitude = latDegrees + (latMinutes / 60);

                    //convert longitude to decimal degrees format
                    double lon = Utils.ToDouble(items[4]);
                    if (items[5] == "W")
                    {
                        lon = -lon;
                    }
                    int lonDegrees = (int)(lon / 100);
                    double lonMinutes = (double)(lon - lonDegrees * 100);
                    fix.Longitude = lonDegrees + (lonMinutes / 60);

                    //convert altitude
                    fix.Altitude = Utils.ToDouble(items[9]);

                    //hdop
                    fix.Hdop = Utils.ToDouble(items[8]);

                    //mark fix as valid
                    fix.Valid = true;
                    
                    return fix;
                }
            }
            return null;
        }

        public long AltitudeFt
        {
            get { return ((long)(Altitude * 3.28084)); }
        }

        public override String ToString()
        {
            if (Valid)
            {
                String s = "";
                s += "Time: " + Time + "\r\n";
                s += "Lat: " + Latitude + "\r\n";
                s += "Lon: " + Longitude + "\r\n";
                s += "Alt: " + AltitudeFt + " ft (" + Altitude + " m)\r\n";
                s += "HDOP: " + Hdop + "\r\n";
                return s;
            }
            else
            {
                return "No fix";
            }
        }
    }
}
