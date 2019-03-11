using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmWpfApp.Models
{
    public class MapModel
    {
        private readonly IBl _bl = new FactoryBl().GetInstance();
        public List<Event> Events { get; set; } = new List<Event>();

        public MapModel()
        {
            GetEvents();
        }

        public void GetEvents()
        {
            Events = _bl.GetEvents();
        }

        public async Task<IEnumerable<Report>> GetReports(int eventId)
        {
            return await _bl.GetReportsAsync(r => r.Event.Id == eventId);
        }
    }
}
