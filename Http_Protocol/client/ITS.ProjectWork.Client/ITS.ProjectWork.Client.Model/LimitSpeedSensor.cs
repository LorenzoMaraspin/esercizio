using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.ProjectWork.Client.Model
{
    public class LimitSpeedSensor : Sensor
    {
        public float LimitSpeed { get; set; }
        public string SpeedAlert { get; set; }
        public float ActualSpeed { get; set; }
        public LimitSpeedSensor()
        {

        }
        public LimitSpeedSensor(int sensorId)
        {
            SensorId = sensorId;
            Type = "LimitSpeedSensor";
            Date = DateTime.Now;
            LimitSpeed = 15;
        }
        public string GetSpeed()
        {
            var random = new Random();
            string message = String.Empty;
            ActualSpeed = random.Next(50);
            message  = LimitSpeedAlert(ActualSpeed);
            return message;

        }
        public string LimitSpeedAlert(float actualSpeed)
        {
            if(actualSpeed >= LimitSpeed)
            {
                SpeedAlert = "hai superato il limite di velocita";
                actualSpeed = LimitSpeed;
            }
            else
            {
                SpeedAlert = actualSpeed.ToString();
            }
            return SpeedAlert;
        }
    }
}
