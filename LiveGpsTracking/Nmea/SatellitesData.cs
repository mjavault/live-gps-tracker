using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveGpsTracking.Nmea
{
    class SatellitesData
    {
        public int Satellites;

        public static SatellitesData Parse(String nmea)
        {
            //"$GPGSV,num%u,id%u,view%u"
            String[] items = nmea.Split(',');
            if (items.Length == 20 && items[1] != "0")
            {
                SatellitesData s = new SatellitesData();
                s.Satellites = Utils.ToInt(items[3]);
                return s;
            }
            return null;
        }

        public override String ToString()
        {
            String s = "";
            s += "Satellites: " + Satellites + "\r\n";
            return s;
        }
    }
}
