using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ITS.ProjectWork.Client.Model
{
    public class SpeedSensor : Sensor
    {
        public float Speed { get; set; }
        
        public SpeedSensor()
        {
            SensorId = "5";
            Type = "SpeedSensor";
        }

        public float ReturnSpeed()
        {
            var random = new Random();
            Speed = random.Next(50);
            return Speed;
        }
        /*public string LimitSpeedAlert()
        {
            var LimitSpeed = 30;
            float actualSpeed = ReturnSpeed();
            if (actualSpeed >= LimitSpeed)
            {
               var alertSpeed = ("hai superato il limite di velocita");
            }
            else
            {
                actualSpeed.ToString();
            }
            return actualSpeed.ToString();
        }*/
        public string GetJson()
        {
            var obj = new
            {
                sensorId = SensorId,
                type = Type,
                date = DateTime.Now.ToString(),
                value = ReturnSpeed(),

            };
            string JsonSpeedSensor = JsonConvert.SerializeObject(obj);
            Console.WriteLine(JsonSpeedSensor);
            return JsonSpeedSensor;
        }
    }
}
