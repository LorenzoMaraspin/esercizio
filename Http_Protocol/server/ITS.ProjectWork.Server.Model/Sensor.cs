using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITS.ProjectWork.Server.Model
{
    public class Sensor 
    {
        [Key]
        public int SensorId { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string Values { get; set; }
    }
}
