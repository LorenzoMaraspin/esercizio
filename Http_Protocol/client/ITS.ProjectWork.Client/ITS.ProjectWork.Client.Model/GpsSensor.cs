using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.ProjectWork.Client.Model
{
    public class GpsSensor : Sensor
    {
        public int Latitude { get; set; }
        public int Longitude { get; set; }
        public GpsSensor()
        {

        }
        public GpsSensor(int sensorId)
        {
            SensorId = sensorId;
            Type = "GpsSensor";
            Date = DateTime.Now;
        }
        public string GetPosition()
        {
            var random = new Random();
            Latitude = random.Next(-90, 90);
            Longitude = random.Next(-180, 180);
            return "Lat = " + Latitude + " - " + "Long = " + Longitude;
        }
    }
}
