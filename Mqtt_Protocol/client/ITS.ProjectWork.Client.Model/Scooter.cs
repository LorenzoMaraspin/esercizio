using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ITS.ProjectWork.Client.Model
{
    public class Scooter
    {
        public string ScooterId { get; set; }
        public float BatteryVoltage { get; set; }
        public float MaxSpeed { get; set; }
        public float MinSpeed { get; set; }
        public int TimeOfCharge { get; set; }


        public Scooter()
        {
            ScooterId = "1";
        }
        public string GetJson()
        {
            var scooter = new
            {
                ScooterId = ScooterId,
                BatteryVoltage = 15,
                MaxSpeed = 50,
                MinSpeed = 5,
                TimeOfCharge = 3
            };

            string jsonString = JsonConvert.SerializeObject(scooter);
            Console.WriteLine(jsonString);
            return jsonString;
        }
    }
}
