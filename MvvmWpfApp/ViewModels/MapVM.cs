using MvvmWpfApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using BE;
using Microsoft.Maps.MapControl.WPF;
using MvvmWpfApp.Annotations;
using MvvmWpfApp.Utils;

namespace MvvmWpfApp.ViewModels
{
    public class MapVM: INotifyPropertyChanged
    {
        public MapModel MapModel { get; set; }
        public ObservableCollection<string>EventsId { get; set; }
        public ObservableCollection<string> SelectedEvents { get; set; }
        public ObservableCollection<Pushpin> LocationList { get; set; }
        public ObservableCollection<Report> Reports { get; set; }

        public RelayCommand<string> SelectedEventsComand { get; set; }

        public MapVM()
        {
            MapModel = new MapModel();
            MapModel.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "Events")
                {
                   App.Current.Dispatcher.Invoke(SetEventsIds);
                }
            };
            SelectedEvents = new ObservableCollection<string>();
            Reports = new ObservableCollection<Report>();
            EventsId = new ObservableCollection<string>();
            EventsId.CollectionChanged += (sender, args) =>
            {
                OnPropertyChanged("EventsId");
            };

            LocationList = new ObservableCollection<Pushpin>();
            LocationList.CollectionChanged += (sender, args) =>
            {
                OnPropertyChanged("LocationList");
            };

            SelectedEventsComand = new RelayCommand<string>(SelectedChanged);

            SetEventsIds();
        }

        private void SetEventsIds()
        {
            EventsId.Clear();
            foreach (var _event in MapModel.Events)
            {
                EventsId.Add(_event.Id + ": " + _event.StartTime);
            }
        }

        private void SelectedChanged(string obj)
        {
            SelectedChangedAsync(obj);
        }

        private async Task SelectedChangedAsync(string obj)
        {
            var pushpin = new Pushpin();
            var eventId = Convert.ToInt32(obj.Split(':')[0]);
            if (SelectedEvents.Any(s => s == obj))
            {
                SelectedEvents.Remove(obj);
                foreach (var report in Reports)
                {
                    if (report.Event.Id != eventId) continue;
                    pushpin = LocationList.FirstOrDefault(p =>
                        p.Location.Equals(new Location(report.Latitude, report.Longitude)));
                    LocationList.Remove(pushpin);
                    Reports.Remove(report);
                }
            }
            else
            {
                var reports = await MapModel.GetReports(eventId);
                foreach (var report in reports)
                {
                    Reports.Add(report);
                    pushpin.Location = new Location(report.Latitude, report.Longitude);
                    LocationList.Add(pushpin);
                    SelectedEvents.Add(obj);
                }
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
