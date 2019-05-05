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
    public class MapVM : INotifyPropertyChanged
    {
        public MapModel MapModel { get; set; }
        public ObservableCollection<Event> Events
        {
            get { return new ObservableCollection<Event>(MapModel.Events); }
            set { MapModel.Events = new List<Event>(value); }
        }
        public ObservableCollection<Event> SelectedEvents { get; set; }

        public ObservableCollection<Pushpin> LocationList
        {
            get
            {
                return new ObservableCollection<Pushpin>(
                    Reports.Select(r => new Pushpin()
                    {
                        Location = new Location(r.Latitude, r.Longitude)
                    })
                    );
            }
        }

        public ObservableCollection<Report> Reports { get; set; }

        public RelayCommand<Event> SelectedEventsComand { get; set; }

        public MapVM()
        {
            MapModel = new MapModel();
            MapModel.PropertyChanged += (sender, args) =>
            {
                OnPropertyChanged(nameof(Events));
            };
            SelectedEvents = new ObservableCollection<Event>();
            Reports = new ObservableCollection<Report>();

            Events.CollectionChanged += (sender, args) =>
            {
                OnPropertyChanged(nameof(Events));
            };

            LocationList.CollectionChanged += (sender, args) =>
            {
                OnPropertyChanged(nameof(LocationList));
            };

            SelectedEventsComand = new RelayCommand<Event>(SelectedChanged);

        }


        private void SelectedChanged(object obj)
        {
            if (obj is Event @event)
            {
                SelectedChangedAsync(@event);
            }
        }

        private async Task SelectedChangedAsync(Event _event)
        {
            if (SelectedEvents.All(e => e != _event))
            {
                foreach (var report in Reports.ToArray())
                {
                    if (report.Event.Id == _event.Id)
                        Reports.Remove(report);
                }
            }
            else
            {
                var reports = await MapModel.GetReports(_event.Id);
                foreach (var report in reports)
                {
                    Reports.Add(report);
                }
            }
            OnPropertyChanged(nameof(LocationList));
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
