using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public GeoCoordinate RealLocation { get; set; }
        public GeoCoordinate CalculateLocation { get; set; }
        
        public ICollection<Report> Reports { get; set; }
    }
}
