using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.ProjectWork.Client.Model
{
    public class BatterySensor : Sensor
    {
        public float Temperature { get; set; }
        public float Voltage { get; set; }
        public float ElectricCurrent { get; set; }

        public BatterySensor()
        {

        }
        public BatterySensor(int sensorId)
        {
            SensorId = sensorId;
            Type = "BatterySensor";
            Date = DateTime.Now;
        }

        public float[] GenerateRandomValue()
        {
            float[] values = new float[3];
            var random = new Random();
            values[0] = random.Next(50);
            values[1] = random.Next(13,15);
            values[2] = random.Next(20);

            return values;
        }

        public string CalculateBatteryPercent(float VoltageBattery)
        {
            float[] values = GenerateRandomValue();
            Temperature = values[0];
            Voltage = values[1];
            ElectricCurrent = values[2];
            int i;

            string PercentBattery = String.Empty;
            if(Voltage >= VoltageBattery)
            {
                PercentBattery = "100%";
            }
            else if((Voltage >= VoltageBattery - 0.30)&&(Voltage < VoltageBattery)){
                PercentBattery = "75%";
            }
            else if ((Voltage >= VoltageBattery - 0.60) && (Voltage < VoltageBattery - 0.30))
            {
                PercentBattery = "50%";
            }
            else if ((Voltage >= VoltageBattery - 0.90) && (Voltage < VoltageBattery - 0.60))
            {
                PercentBattery = "25%";
            }
            else if ((Voltage >= VoltageBattery - 1.20) && (Voltage < VoltageBattery - 0.90))
            {
                PercentBattery = "0%";
            }
           /* for(i = 0; i < 200; i++)
            {
                while(i >= 200)
                {
                    PercentBattery--;
                }
            }*/
            return PercentBattery;
        }
    }
}
