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
        public bool Availability { get; set; }
        public float BatteryVoltage { get; set; }
        public float MaxSpeed { get; set; }
        public float MinSpeed { get; set; }
        public int TimeOfCharge { get; set; }
        public BatterySensor BatterySensor { get; set; }
        public BrightnessSensor BrightnessSensor { get; set; }
        public GpsSensor GpsSensor { get; set; }
        public LimitSpeedSensor LimitSpeedSensor { get; set; }
        public SpeedSensor SpeedSensor { get; set; }
        public int SensorId = 1;
        public int SensorList = 1;

        public Scooter()
        {

        }

        public Scooter(string scooterId, bool availability, float battery, float max, float min, int charge)
        {
            ScooterId = scooterId;
            Availability = availability;
            BatteryVoltage = battery;
            MaxSpeed = max;
            MinSpeed = min;
            TimeOfCharge = charge;
        }
        public void GetJson()
        {
            // string path = @"C:\Desktop\file.json";
            // FileStream fileStream = File.Create(path);

            BatterySensor = new BatterySensor(SensorId);
            string battery = BatterySensor.CalculateBatteryPercent(TimeOfCharge);
            SpeedSensor = new SpeedSensor(SensorId + 1);
            string speed = SpeedSensor.ReturnSpeed().ToString();
            LimitSpeedSensor = new LimitSpeedSensor(SensorId + 2);
            string limitSpeed = LimitSpeedSensor.GetSpeed();
            GpsSensor = new GpsSensor(SensorId + 3);
            string gps = GpsSensor.GetPosition();
            BrightnessSensor = new BrightnessSensor(SensorId + 4);
            string brigthness = BrightnessSensor.ReturnValues();
            var obj = new
            {
                scooterId = ScooterId,
                availability = Availability,
                battery = BatteryVoltage,
                max = MaxSpeed,
                min = MinSpeed,
                charge = TimeOfCharge,
                sensors = new
                {
                   sensorBattery = new { id = BatterySensor.SensorId, battery = battery, type = BatterySensor.Type, data = BatterySensor.Date, sensorList = SensorList },
                   brightnessSensor = new { id = BrightnessSensor.SensorId, brightness = brigthness, tupe = BrightnessSensor.Type, data = BrightnessSensor.Date, sensorList = SensorList },
                   gpsSensor = new {id = GpsSensor.SensorId, type = GpsSensor.Type, gps = gps, data = GpsSensor.Date, sensorList = SensorList },
                   speedSensor = new {id = SpeedSensor.SensorId, type = SpeedSensor.Type, speed = speed, data = SpeedSensor.Date, sensorList = SensorList },
                   limitSpeedSensor = new { id = LimitSpeedSensor.SensorId, type = LimitSpeedSensor.Type, limit = limitSpeed, data = LimitSpeedSensor.Date, sensorList = SensorList }
                },
            };
            File.WriteAllText(@"c:\file.json", JsonConvert.SerializeObject(obj));
            using (StreamWriter file = File.CreateText(@"C:\\file.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, obj);
            }
            SensorList++;
            /*var result = JsonConvert.SerializeObject(obj, Formatting.Indented);
            using (var tw = new StreamWriter(fileStream))
            {
                tw.WriteLine(result.ToString());
                tw.Close();
            }*/
        }
    }
}
