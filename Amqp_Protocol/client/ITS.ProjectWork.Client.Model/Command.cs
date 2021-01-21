using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.ProjectWork.Client.Model
{
    public class Command
    {
        public int ScooterId { get; set; }
        public float BatteryVoltage { get; set; }
        public float MaxSpeed { get; set; }
        public float MinSpeed { get; set; }
        public int TimeOfCharge { get; set; }
    }
}
