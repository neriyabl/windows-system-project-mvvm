using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public DateTime EndTime { get; set; }
        public double RealLAtitude { get; set; }
        public double RealLongitude { get; set; }

        public ICollection<Report> Reports { get; set; }
    }
}
