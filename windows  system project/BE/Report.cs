using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Report
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Address { get; set; }
        public DbGeography Location { get; set; }
        public DateTime Time { get; set; }
        public int NoiseIntensity { get; set; }
        public int NumOfExplosions { get; set; }
        public Event Event { get; set; }
    }
}
