﻿using BE;
using MvvmWpfApp.Annotations;
using MvvmWpfApp.Models;
using MvvmWpfApp.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MvvmWpfApp.ViewModels
{
    public class ChooseExplosionsVM : INotifyPropertyChanged
    {
        public ChooseExplosionsModel chooseExplosionsModel { get; set; }
        public ObservableCollection<Explosion> ExplosionsFromEvent { get; set; }
        public Event Event { get; set; }

        public RelayCommand<string> SelectedEventsComand { get; set; }
        public string Title { get; private set; }

        public ChooseExplosionsVM()
        {
            chooseExplosionsModel = new ChooseExplosionsModel();
            chooseExplosionsModel.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "Events")
                {
                    App.Current.Dispatcher.Invoke(updateExplosionsFromEvent);
                }
            };
            ExplosionsFromEvent = new ObservableCollection<Explosion>();
            ExplosionsFromEvent.CollectionChanged += (sender, args) =>
            {
                OnPropertyChanged("ExplosionsFromEvent");
            };

            updateExplosionsFromEvent();
        }

        ICollection<Explosion> getExplosionsFromEvent(Event _event)
        {
            return _event.Explosions;
        }

        private void updateExplosionsFromEvent()
        {
            ExplosionsFromEvent.Clear();
            ExplosionsFromEvent = getExplosionsFromEvent(Event) as ObservableCollection<Explosion>;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}