using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace LiveGpsTracking
{
    public class HttpUtils
    {
        public class Response
        {
            public bool Success;
            public string Content;
            public Response(bool success, string content)
            {
                this.Success = success;
                this.Content = content;
            }
        }

        public static Response Get(string url, params object[] args)
        {
            try
            {
                String uri = String.Format(url, args);
                WebClient w = new WebClient();
                String content = w.DownloadString(uri);
                return new Response(true, content);
            }
            catch (System.Net.WebException ex)
            {
                Console.WriteLine(ex);
                String content = null;
                if (ex.Response != null)
                {
                    using (StreamReader reader = new StreamReader(ex.Response.GetResponseStream()))
                        content = reader.ReadToEnd().Trim();
                }
                return new Response(false, content);
            }
        }

        public static Response Put(string url, string data)
        {
            try
            {
                WebClient w = new WebClient();
                w.Headers.Add("Cache-Control", "no-cache");
                w.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                String content = w.UploadString(url, "PUT", data);
                return new Response(true, content);
            }
            catch (System.Net.WebException ex)
            {
                Console.WriteLine(ex);
                String content = null;
                if (ex.Response != null)
                {
                    using (StreamReader reader = new StreamReader(ex.Response.GetResponseStream()))
                        content = reader.ReadToEnd().Trim();
                }
                return new Response(false, content);
            }
        }

        public static Response Post(string url, string data, string contentType = "application/x-www-form-urlencoded", List<String> headers = null)
        {
            try
            {
                WebClient w = new WebClient();
                w.Headers.Add("Cache-Control", "no-cache");
                w.Headers.Add("Content-Type", contentType);
                if (headers != null)
                {
                    foreach (String header in headers)
                    {
                        w.Headers.Add(header);
                    }
                }
                String content = w.UploadString(url, "POST", data);
                return new Response(true, content);
            }
            catch (System.Net.WebException ex)
            {
                Console.WriteLine(ex);
                String content = null;
                if (ex.Response != null)
                {
                    using (StreamReader reader = new StreamReader(ex.Response.GetResponseStream()))
                        content = reader.ReadToEnd().Trim();
                }
                return new Response(false, content);
            }
        }
    }
}
