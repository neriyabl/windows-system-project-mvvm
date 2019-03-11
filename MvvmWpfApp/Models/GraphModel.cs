using BE;
using BL;
using MvvmWpfApp.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MvvmWpfApp.Models
{
    class GraphModel : INotifyPropertyChanged
    {
        private readonly IBl _bl = new FactoryBl().GetInstance();

        private List<Event> _events = new List<Event>();
        public List<Event> Events
        {
            get { return _events; }
            set
            {
                _events = value;
                OnPropertyChanged();
            }
        }

        public GraphModel()
        {
            GetEvents();
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += checkNewEvents;
            worker.RunWorkerAsync();
        }

        private void checkNewEvents(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            while (true)
            {
                GetEvents();
                Thread.Sleep(5000);
            }
        }

        public void GetEvents()
        {
            Events = _bl.GetEvents();
        }

        public async Task<IEnumerable<Report>> GetReports(int eventId)
        {
            return await _bl.GetReportsAsync(r => r.Event.Id == eventId);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
