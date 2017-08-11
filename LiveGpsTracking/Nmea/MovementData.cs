using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveGpsTracking.Nmea
{
    class MovementData
    {
        public DateTime Time;
        public double Speed;
        public double Bearing;

        public static MovementData Parse(String nmea)
        {
            //"$GPRMC,time%f,status%c,lat%f,latdir%c,lon%f,londir%c,speed%f,bearing%f,date%lu"                        
            String[] items = nmea.Split(',');
            if (items.Length == 13 && items[2] == "A")
            {
                MovementData t = new MovementData();
                //fix.speed *= 1.852; //knot to km/h
                t.Speed = Utils.ToDouble(items[7]) * 0.514444; //knot to m/s
                t.Bearing = Utils.ToDouble(items[8]);
                int year = Utils.ToInt(items[9].Substring(4, 2));
                if (year < 50)
                {
                    year += 2000;
                }
                t.Time = new DateTime(
                    year,
                    Utils.ToInt(items[9].Substring(2, 2)),
                    Utils.ToInt(items[9].Substring(0, 2)),
                    Utils.ToInt(items[1].Substring(0, 2)),
                    Utils.ToInt(items[1].Substring(2, 2)),
                    Utils.ToInt(items[1].Substring(4, 2)),
                    DateTimeKind.Utc);
                return t;
            }
            return null;
        }

        public override String ToString()
        {
            String s = "";
            s += "Time: " + Time + "\r\n";
            s += "Speed: " + Math.Round(Speed * 
				3.6, 0) + " km/h (" +Math.Round(Speed, 2) + " m/s)\r\n";
            s += "Bearing: " + Bearing + "\r\n";
            return s;
        }
    }
}
