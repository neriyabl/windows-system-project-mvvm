﻿using MvvmWpfApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

namespace MvvmWpfApp.Views
{
    /// <summary>
    /// Interaction logic for ChooseExplosionsView.xaml
    /// </summary>
    public partial class ChooseExplosionsView : UserControl
    {
        public ChooseExplosionsView()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty ChooseExplosionsVmProperty = DependencyProperty.Register(
   "ChooseExplosionsVm", typeof(ChooseExplosionsVM), typeof(ChooseExplosionsView), new PropertyMetadata(default(ChooseExplosionsVM)));

        public ChooseExplosionsVM ChooseExplosionsVm
        {
            get { return (ChooseExplosionsVM)GetValue(ChooseExplosionsVmProperty); }
            set
            {
                SetValue(ChooseExplosionsVmProperty, value);
                value.PropertyChanged += Value_PropertyChanged;
                DataContext = ChooseExplosionsVm;
            }
        }

        private void Value_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            DataContext = ChooseExplosionsVm;
        }

    }
}
