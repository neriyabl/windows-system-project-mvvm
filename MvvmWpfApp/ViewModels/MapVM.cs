using MvvmWpfApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maps.MapControl.WPF;
using MvvmWpfApp.Annotations;

namespace MvvmWpfApp.ViewModels
{
    class MapVM: INotifyPropertyChanged
    {
        public MapModel MapModel { get; set; }
        public ObservableCollection<string>EventsId { get; set; }
        public ObservableCollection<Pushpin> LocationList { get; set; }

        public MapVM()
        {
            MapModel = new MapModel();
            EventsId = new ObservableCollection<string>();
            LocationList = new ObservableCollection<Pushpin>();
            foreach (var _event in MapModel.Events)
            {
                EventsId.Add(_event.Id + ": " + _event.StartTime);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
