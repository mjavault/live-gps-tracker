using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveGpsTracking
{
    class Utils
    {
        public static double ToDouble(String str)
        {
            try
            {
                if (str != null && str.Trim().Length > 0)
                    return Convert.ToDouble(str);
                else
                    return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static int ToInt(String str)
        {
            try
            {
                if (str != null && str.Trim().Length > 0)
                    return Convert.ToInt32(str);
                else
                    return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
