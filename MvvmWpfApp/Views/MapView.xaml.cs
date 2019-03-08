﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Maps;
using MvvmWpfApp.Annotations;
using MvvmWpfApp.ViewModels;
using Microsoft.Maps.MapControl.WPF;

namespace MvvmWpfApp
{
    /// <summary>
    /// Interaction logic for MapUC.xaml
    /// </summary>
    public partial class MapView : UserControl, INotifyPropertyChanged
    {

        public MapView()
        {
            InitializeComponent();
            BingMap.Height = SystemParameters.PrimaryScreenHeight * 0.80;
            BingMap.Width = SystemParameters.PrimaryScreenWidth * 0.70;
            EventsCheckCB.DataContext = mapVM.Events_ID;

            //************************************
            //Example Adding PushPin in Jerusalem:
            Pushpin pushPin = new Pushpin();
            pushPin.Location = new Location(31.7962419, 35.3154441);
            BingMap.Children.Add(pushPin);
            //TODO: Edit the pushPins to binding Reports List
            //************************************
        }

        private MapVM mapVM { get; set; } = new MapVM();

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
