using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.ProjectWork.Client.Model
{
    public class Sensor
    {
        public Sensor()
        {

        }
        public int SensorId { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }

        /*public string GetSensorId(string type)
        {
            return SensorId;
        }*/
    }
}
