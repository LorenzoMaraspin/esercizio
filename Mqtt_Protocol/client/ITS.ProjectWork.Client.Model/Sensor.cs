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
        public string SensorId { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public Scooter Scooter { get; set; }

       /* public string GetJson()
        {
            SpeedSensor speedSensor = new SpeedSensor();
            GpsSensor gpsSensor = new GpsSensor();
            BrightnessSensor brightnessSensor = new BrightnessSensor();
            BatterySensor batterySensor = new BatterySensor();
            var Json =(
                speedSensor.GetJson(),
                gpsSensor.GetJson(),
                brightnessSensor.GetJson(),
                batterySensor.GetJson()
                );
            return Json.ToString();
        }*/
    }
}
