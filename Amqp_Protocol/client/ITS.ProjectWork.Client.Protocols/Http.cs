using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace ITS.ProjectWork.Client.Protocols
{
    public class Http : IProtocolInterface
    {
        private string endpoint;
        private HttpWebRequest httpWebRequest;
        public Http()
        {

        }

        public Http(string endpoint)
        {
            this.endpoint = endpoint;
        }
       /* public List<Scooter> Get()
        {
            var client = new WebClient();
            // GET
            var result = client.DownloadString("https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/2.5_day.geojson%22);

            //deserializzazione del json ricevuto
            var list = JsonConvert.DeserializeObject<EarthQuakeJsonResponse>(result);

            //creazione lista di obj
            var listObj = new List<EarthQuakeClass>();


            foreach (var item in list.Earthquakes)
            {
                var obj = new EarthQuakeClass();

                //partizionamento stringa (solo parte interessata)
                var str = item.Properties.Place;
                var split = str.Split(',');

                obj.EarthQuakeId = item.Id;
                obj.Magnitude = item.Properties.Magnitude;
                obj.Place = split[1];
                obj.Time = item.Properties.Time;
                obj.Title = item.Properties.Title;
                listObj.Add(obj);
            }
            return listObj;
        }*/

        public void Get(string data)
        {
            throw new NotImplementedException();
        }

        public void Send(string data, string topic)
        {
            /*httpWebRequest = (HttpWebRequest)WebRequest.Create(endpoint);
            httpWebRequest.ContentType = "text/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(data);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            Console.Out.WriteLine(httpResponse.StatusCode);

            httpResponse.Close();*/
            WebClient client = new WebClient();
            var Json = client.DownloadString("http://localhost:8011/scooters");

            var dJson = JsonConvert.DeserializeObject(Json, new JsonSerializerSettings()
            {
                Error = (sender, e) =>
                {
                    e.ErrorContext.Handled = true;
                }
            });
            Console.WriteLine("{0}", dJson);
            //return dJson;
        }
    }
 }
