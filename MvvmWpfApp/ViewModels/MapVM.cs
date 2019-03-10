using MvvmWpfApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmWpfApp.ViewModels
{
    class MapVM
    {
        public MapModel mapModel { get; set; }
        public List<string> Events_ID { get; set; } = new List<string>();

        public MapVM()
        {
            mapModel = new MapModel();
            foreach (var _event in mapModel.Events)
            {
                Events_ID.Add(_event.Id + ": " + _event.StartTime);
            }
        }
    }
}
