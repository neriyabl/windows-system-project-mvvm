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

namespace MvvmWpfApp.ViewModels
{
    class GraphVM : INotifyPropertyChanged
    {
        public GraphModel GraphModel { get; set; }
        public ObservableCollection<string> EventsId { get; set; }
        public ObservableCollection<Report> Reports { get; set; }

        public RelayCommand<string> SelectedEventsComand { get; set; }

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
