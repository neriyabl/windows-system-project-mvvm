using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmWpfApp.Models
{
    class MapModel
    {
        public MapModel()
        {
            Events = _bl.GetEvents();
        }

        private readonly IBl _bl = new FactoryBl().GetInstance();
        public List<Event> Events { get; set; } = new List<Event>();
    }
}
