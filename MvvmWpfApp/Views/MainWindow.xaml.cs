﻿using System;
using System.Collections.Generic;
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
using System.Reflection;
using log4net;
using MvvmWpfApp.ViewModels;


namespace MvvmWpfApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly ILog Log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public MainViewModel MainViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            MainViewModel = new MainViewModel();
            ReportFormView.ReportFormVm = MainViewModel.NewReportFormVm;
            MapView.MapVm = MainViewModel.MapVm;
            DataContext = MainViewModel;
            Closing += MainView_Closing;
        }

        private void MainView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            /*
                if (((MainViewModel)(this.DataContext)).Data.IsModified)
                if (!((MainViewModel)(this.DataContext)).PromptSaveBeforeExit())
                {
                    e.Cancel = true;
                    return;
                }
            */
            Log.Info("Closing App");
        }

        private void SelectedTabChange(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button) e.Source).Uid);

            GridCursor.Margin = new Thickness((150 * index), 0, 0, 0);

            if (index == 0)
            {
                #region toShow

                ReportFormView.Visibility = Visibility.Visible;
                MapView.Visibility = Visibility.Visible;

                #endregion

                #region toHide

                #endregion
            }
            else if (index == 1)
            {
                #region toShow

                #endregion

                #region toHide

                ReportFormView.Visibility = Visibility.Collapsed;
                MapView.Visibility = Visibility.Collapsed;

                #endregion
            }
        }
    }
}