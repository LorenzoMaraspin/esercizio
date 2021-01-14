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

        public void Send(string data)
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
