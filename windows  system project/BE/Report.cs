using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Report
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Time { get; set; }
        public int NoiseIntensity { get; set; }
        public int NumOfExplosions { get; set; }
        public int EventId { get; set; }
    }
}
