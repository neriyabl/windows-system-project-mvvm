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
    public class Event: ICloneable
    {
        [Key]
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public ICollection<Explosion> Explosions { get; set; }
        public ICollection<Report> Reports { get; set; }

        public Object Clone()
        {
            return new Event()
            {
                Id = Id,
                StartTime = new DateTime(StartTime.Ticks),
                Explosions = (from explosion in Explosions select explosion?.Clone() as Explosion).ToList(),
                Reports = (from report in Reports select report?.Clone() as Report).ToList(),
            };
        }
    }
}
