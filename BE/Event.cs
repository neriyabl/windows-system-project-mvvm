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
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        // public DbGeography RealLocation { get; set; }
        // public DbGeography CalculateLocation { get; set; }
        
        public ICollection<Report> Reports { get; set; }
    }
}
