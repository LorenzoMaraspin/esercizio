using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITS.ProjectWork.Server.Model
{
    public class Scooter : EntityBase<int>
    {
        public int ScooterId { get; set; }
        [Required]
        public bool Availability { get; set; }
        public float BatteryVoltage { get; set; }
        public float MaxSpeed { get; set; }
        public float MinSpeed { get; set; }
    }
}
