using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;
using MvvmWpfApp.Models;
using System.Collections.ObjectModel;
using MvvmWpfApp.Utils;
using BE;
using System.ComponentModel;
using MvvmWpfApp.Annotations;
using System.Runtime.CompilerServices;
using System.Device.Location;

namespace MvvmWpfApp.ViewModels
{
    public class GraphVM : INotifyPropertyChanged
    {
        public GraphModel GraphModel { get; set; }
        public ObservableCollection<string> EventsId { get; set; }
        public ObservableCollection<Report> Reports { get; set; }

        public RelayCommand<string> SelectedEventsComand { get; set; }
        public string Title { get; private set; }

        public IList<DataPoint> Points
        {
            get
            {
                return (from explosion in GraphModel.Explosions
                        select new DataPoint(GraphModel.Explosions.IndexOf(explosion),
                            new GeoCoordinate(explosion.ApproxLatitude, explosion.ApproxLongitude)
                            .GetDistanceTo(
                                new GeoCoordinate(explosion.RealLatitude, explosion.RealLongitude)
                                ))).ToList();
            }
        }
        public GraphVM()
        {
            GraphModel = new GraphModel();
            GraphModel.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "Events")
                {
                    App.Current.Dispatcher.Invoke(SetEventsIds);
                }
            };
            Reports = new ObservableCollection<Report>();
            EventsId = new ObservableCollection<string>();
            EventsId.CollectionChanged += (sender, args) =>
            {
                OnPropertyChanged("EventsId");
            };

            SetEventsIds();

            ///////////////////////////////////////////////
            //TODO: Change to real DataBinding:

            this.Title = "Graph";
            List<DataPoint> list = new List<DataPoint>();
            foreach (var item in Reports)
            {
                double latMiss = 0;
                double lonMiss = 0;

                list.Add(new DataPoint(latMiss, lonMiss));
            }
            //Mock:
            //this.Points
                //new List<DataPoint>
                //              {
                //                  new DataPoint(0, 4),
                //                  new DataPoint(10, 13),
                //                  new DataPoint(20, 15),
                //                  new DataPoint(30, 16),
                //                  new DataPoint(40, 12),
                //                  new DataPoint(50, 12)
                //              };

            ///////////////////////////////////////////////
        }

        private void SetEventsIds()
        {
            EventsId.Clear();
            foreach (var _event in GraphModel.Events)
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
