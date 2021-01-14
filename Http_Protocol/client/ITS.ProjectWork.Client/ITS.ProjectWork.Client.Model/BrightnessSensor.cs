using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.ProjectWork.Client.Model
{
    public class BrightnessSensor : Sensor
    {
        public bool Light { get; set; }
        public TimeSpan LimitOn { get; set; }
        public TimeSpan LimitOff { get; set; }
        public TimeSpan TimeRandom { get; set; }


        public BrightnessSensor()
        {

        }
        public BrightnessSensor(int sensorId) 
        {
            SensorId = sensorId;
            Type = "BrightnessSensor";
            Date = DateTime.Now;
            LimitOn = TimeSpan.FromHours(18);
            LimitOff = TimeSpan.FromHours(5);

        }
        public int GenerateRandomTime()
        {
            TimeSpan start = TimeSpan.FromHours(0);
            TimeSpan end = TimeSpan.FromHours(23);
            var random = new Random();
            int maxMinutes = (int)((end - start).TotalMinutes);
            int hours = (random.Next(maxMinutes)/60);

            return hours;
        }
        public void OpenCloseLight()
        {
            int hours = GenerateRandomTime();
            TimeRandom = new TimeSpan(hours, 0, 0);
            //TimeRandom = LimitOn.Add(TimeSpan.FromHours(minutes));

            if((TimeRandom >= LimitOn)&&(!(TimeRandom < LimitOff)))
            {
                if (Light == false)
                    Light = true;
                else
                    Light = true;
            }
            if ((TimeRandom >= LimitOff) && (TimeRandom < LimitOn))
            {
                Light = false;
                if (Light == true)
                    Light = false;
                else
                    Light = false;
            }
        }
        public string ReturnValues()
        {
            OpenCloseLight();
            return "Time: " + TimeRandom + " state: " + Light.ToString();
        }
    }
}
