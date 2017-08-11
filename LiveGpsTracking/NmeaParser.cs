using LiveGpsTracking.Nmea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveGpsTracking
{
    class NmeaParser
    {
        public FixData Fix;
        public MovementData Movement;
        public SatellitesData Satellites;
        private double lastAltitude;
        private int lastAltTimeSeconds;
        public double VerticalSpeed;
        public double MaximumAltitude;

        public void Update(String line)
        {
            try
            {
                //validate checksum first
                if (IsValidChecksum(line))
                {
                    if (line.StartsWith("$GPGGA"))
                    {
                        FixData newFix = FixData.Parse(line);
                        if (newFix != null && newFix.Valid)
                        {
                            //compute vertical speed
                            int newAltTimeSeconds = (newFix.Time.Hour * 3600)
                                + (newFix.Time.Minute * 60)
                                + (newFix.Time.Second);
                            double dt = newAltTimeSeconds - lastAltTimeSeconds;
                            if (lastAltitude > 0 && dt > 0)
                            {
                                double newVS = (newFix.Altitude - lastAltitude) / (dt);
                                VerticalSpeed = VerticalSpeed + 0.2f * (newVS - VerticalSpeed);
                            }
                            lastAltitude = newFix.Altitude;
                            lastAltTimeSeconds = newAltTimeSeconds;

                            //compute maximum altitude
                            if (newFix.Altitude > MaximumAltitude)
                            {
                                MaximumAltitude = newFix.Altitude;
                            }
                        }
                        this.Fix = newFix;

                    }
                    else if (line.StartsWith("$GPRMC"))
                    {
                        this.Movement = MovementData.Parse(line);
                    }
                    else if (line.StartsWith("$GPGSV"))
                    {
                        this.Satellites = SatellitesData.Parse(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public bool IsValidChecksum(String line) {
            int dataSize = line.IndexOf('*');
            if (dataSize > 0 && dataSize <= line.Length - 3)
            {
                //compute checksum
                int checksum = 0;
                for (int i = 1; i < dataSize; i++)
                {
                    checksum ^= Convert.ToByte(line[i]);
                }

                //read checksum from string
                int lineChecksum;
                if (int.TryParse(line.Substring(dataSize + 1, 2), System.Globalization.NumberStyles.AllowHexSpecifier, null, out lineChecksum))
                {
                    return checksum == lineChecksum;
                }
            }
            return false;
        }

        public long VerticalSpeedFpm
        {
            get { return ((long)(VerticalSpeed * 3.28084 * 60)); }
        }

        public override String ToString()
        {
            String s = "";
            if (Fix != null)
            {
                s += Fix.ToString();
            }
            if (Movement != null)
            {
                s += Movement.ToString();
            }
            if (Satellites != null)
            {
                s += Satellites.ToString();
            }
            s += "VSpeed: " + VerticalSpeedFpm + " ft/min (" + Math.Round(VerticalSpeed, 1) + " m/s)\r\n";
            s += "Max Alt: " + ((long)(MaximumAltitude * 3.28084)) + " ft (" + MaximumAltitude + " m)\r\n";
            return s;
        }

        public bool HasFix()
        {
            return Fix != null && Fix.Valid;
        }
    }
}
