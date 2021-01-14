using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.ProjectWork.Client.Model
{
    public class SpeedSensor : Sensor
    {
        public float Speed { get; set; }
        public SpeedSensor()
        {
                
        }
        public SpeedSensor(int sensorId)
        {
            SensorId = sensorId;
            Type = "SpeedSensor";
            Date = DateTime.Now;
        }
        public float ReturnSpeed()
        {
            var random = new Random();
            Speed = random.Next(50);
            return Speed;
        }
    }
}
