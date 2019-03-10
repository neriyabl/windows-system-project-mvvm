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
        private readonly IBl _bl = new FactoryBl().GetInstance();
        public List<Event> Events { get; set; } = new List<Event>();

        public MapModel()
        {
            getEvents();
        }

        public void getEvents()
        {
            Events = _bl.GetEvents();
        }
    }
}
