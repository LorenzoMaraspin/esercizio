using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ITS.ProjectWork.Client.Model
{
    public class GpsSensor : Sensor
    {
        public int Latitude { get; set; }
        public int Longitude { get; set; }
        public GpsSensor()
        {
            SensorId = "4";
            Type = "GpsSensor";
        }

        public string GetPosition()
        {
            var random = new Random();
            Latitude = random.Next(-90, 90);
            Longitude = random.Next(-180, 180);
            return "Lat = " + Latitude + " - " + "Long = " + Longitude;
        }
        public string GetJson()
        {
            var sensor = new
            {
                SensorId = SensorId,
                type = Type,
                date = DateTime.Now.ToString(),
                value = GetPosition()
            };

            string JsonGpsSensor = JsonConvert.SerializeObject(sensor);
            Console.WriteLine(JsonGpsSensor);
            return JsonGpsSensor;
        }
    }
}
