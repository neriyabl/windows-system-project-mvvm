using System;
using System.ComponentModel.DataAnnotations;
using System.Device.Location;

namespace BE
{
    public class Explosion: ICloneable
    {
        [Key]
        public int Id { get; set; }
        public Event Event { get; set; }
        public string RealLatitude { get; set; }
        public string RealLongitude { get; set; }
        public string ApproxLatitude { get; set; }
        public string ApproxLongitude { get; set; }





        public object Clone()
        {
            return new Explosion()
            {
                Id = Id,
                Event = Event?.Clone() as Event,
                RealLatitude = RealLatitude,
                RealLongitude = RealLongitude,
                ApproxLatitude = ApproxLatitude,
                ApproxLongitude = ApproxLongitude
            };
        }
    }
}