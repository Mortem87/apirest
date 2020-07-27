using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace cap_client
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetItem(10);
            GetItems();
            //GetItems("ABC");
            
            PostItem();
            //PutItem(4, "ReplaceItem");
            //DeleteItem(5);
            Console.ReadLine();
        }
        private static void GetItem(int id)
        {
            var url = $"http://localhost:8080/item/{id}";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            // Do something with responseBody
                            Console.WriteLine(responseBody);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
            }
        }/*
        public static string HttpPOST()
        {
            var url = $"https://api.chucknorris.io/jokes/random";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/x-www-form-urlencoded"; // or whatever - application/json, etc, etc
            StreamWriter requestWriter = new StreamWriter(request.GetRequestStream());

            try
            {
                requestWriter.Write(querystring);
            }
            catch
            {
                throw;
            }
            finally
            {
                requestWriter.Close();
                requestWriter = null;
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                return sr.ReadToEnd();
            }
        }*/
        private static void GetItems()
        {
            var url = $"https://api.chucknorris.io/jokes/random";
            //var url = $"http://localhost:8080/items";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            // Do something with responseBody
                            Console.WriteLine(responseBody);

                            ChuckNurris chuck = JsonConvert.DeserializeObject<ChuckNurris>(responseBody);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
            }
        }

        private static void GetItems(string filter)
        {
            var url = $"http://localhost:8080/items?filter={filter}";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            // Do something with responseBody
                            Console.WriteLine(responseBody);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
            }
        }

        private static void PostItem()
        {
            //var url = $"http://localhost:8080/items";
            var url = $"https://api.chucknorris.io/jokes/random";
            string json = "{\"productlist\":[{\"invid\":\"105109\", \"invcodart\":\"PWS - 6900\", \"invdesc\":\"PRECISION PRESS 6\",\"invdepto\":\"218\"},{\"invid\":\"105027\",\"invcodart\":\"17200 - .246CED40 - 1 / 2\",\"invdesc\":\"TP - 1 1 / 4 RD TUBE PIERCING ASSY .246 CEDULA 40 1 / 2 TUBO NEGRO\",\"invdepto\":\"218\"}]}";
            var request = (HttpWebRequest)WebRequest.Create(url);
            //string json = $"{{\"data\":\"{data}\"}}";
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            // Do something with responseBody
                            Console.WriteLine(responseBody);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
                Console.WriteLine(ex.Message);
            }
        }

        private static void PutItem(int id, string data)
        {
            var url = $"http://localhost:8080/items";
            var request = (HttpWebRequest)WebRequest.Create(url);
            string json = $"{{\"id\":\"{id}\",\"data\":\"{data}\"}}";
            request.Method = "PUT";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            // Do something with responseBody
                            Console.WriteLine(responseBody);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
            }
        }

        private static void DeleteItem(int id)
        {
            var url = $"http://localhost:8080/items/{id}";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "DELETE";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            // Do something with responseBody
                            Console.WriteLine(responseBody);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
            }
        }

    }
    public class ChuckNurris
    {
        public List<object> categories { get; set; }
        public string created_at { get; set; }
        public string icon_url { get; set; }
        public string id { get; set; }
        public string updated_at { get; set; }
        public string url { get; set; }
        public string value { get; set; }

    }
}
