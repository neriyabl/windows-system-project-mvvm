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
using BE;
using MvvmWpfApp.ViewModels;

namespace MvvmWpfApp.Views
{
    /// <summary>
    /// Interaction logic for NewReportFormView.xaml
    /// </summary>
    public partial class NewReportFormView : UserControl, INotifyPropertyChanged
    {
        private NewReportFormVM _reportFormVm;
        public NewReportFormVM ReportFormVm
        {
            get => _reportFormVm;
            set
            {
                _reportFormVm = value;
                OnPropertyChanged();
            }
        }

        public NewReportFormView()
        {
            InitializeComponent();
            ReportFormVm = new NewReportFormVM();
            DataContext = ReportFormVm;
            SaveButton.Command = ReportFormVm.AddReportCommand;
            SaveButton.CommandParameter = ReportFormVm.FormModel;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            // Do not load your data at design time
            // if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            // {
            // 	//Load your data here and assign the result to the CollectionViewSource.
            // 	System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["Resource Key for CollectionViewSource"];
            // 	myCollectionViewSource.Source = your data
            // }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ResetForm(object sender, EventArgs e)
        {
            ReportFormVm = new NewReportFormVM();
            DataContext = ReportFormVm;
        }

        private void ActionButton_OnButtonClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}