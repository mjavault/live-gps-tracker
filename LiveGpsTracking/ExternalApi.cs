using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveGpsTracking
{
    class ExternalApi
    {
        private static string HOSTNAME = "https://api.doarama.com/api/0.2/activity";
        private static string API_NAME = "?";
        private static string API_KEY = "?";
        private static string USER_ID = "15608";
        private static string ACTIVITY_ID = "?";

        public static bool DoaramaCreateActivity(double lat, double lon)
        {
            String data = "{\"startLatitude\":" + lat + ",\"startLongitude\":" + lon + ",\"startTime\":" + (DateTime.Now.ToUnixTime() * 1000) + "}";
            List<String> headers = new List<String>();
            headers.Add("api-name:" + API_NAME);
            headers.Add("api-key:" + API_KEY);
            headers.Add("user-id:" + USER_ID);
            headers.Add("Accept:application/json");
            HttpUtils.Response r = HttpUtils.Post(HOSTNAME + "/create", data, "application/json", headers);
            Console.WriteLine(r.Content);
            return r.Success;
        }

        public static bool DoaramaPostLocation(double lat, double lon, double altitude)
        {
            String data = "{"
                + "\"samples\": [ "
                + "{"
                + "\"time\": " + (DateTime.Now.ToUnixTime() * 1000) + ", "
                + "\"coords\": { "
                + "\"latitude\": " + lat + ", "
                + "\"longitude\": " + lon + ", "
                + "\"altitude\": " + altitude
                + "}"
                + "}"
                + "],"
                + "\"activityId\": " + ACTIVITY_ID + ", "
                + "\"altitudeReference\": \"WGS84\" "
                + "}";
            List<String> headers = new List<String>();
            headers.Add("api-name:" + API_NAME);
            headers.Add("api-key:" + API_KEY);
            headers.Add("user-id:" + USER_ID);
            headers.Add("Accept:application/json");
            HttpUtils.Response r = HttpUtils.Post(HOSTNAME + "/record", data, "application/json", headers);
            Console.WriteLine(r.Content);
            return r.Success;
        }

        public static bool PostLocation(Position position)
        {
            String data = "timestamp=" + (DateTime.Now.ToUnixTime() * 1000)
                + "&lat=" + position.Latitude
                + "&lon=" + position.Longitude
                + "&altitude=" + position.Altitude
                + "&key=track";
            HttpUtils.Response r = HttpUtils.Post("http://192.99.180.177:8080/tracking" + "/api/post", data);
            Console.WriteLine(r.Content);
            return r.Success;
            return true;
        }
    }
}
