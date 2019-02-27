using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BE;
using BL;
using MvvmWpfApp.Annotations;
using MvvmWpfApp.Models;
using MvvmWpfApp.Utils;

namespace MvvmWpfApp.ViewModels
{
    public class NewReportFormVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public NewReportFormModel FormModel { get; set; }

        private RelayCommand<NewReportFormModel> _addReportCommand;
        public RelayCommand<NewReportFormModel> AddReportCommand
        {
            get { return _addReportCommand; }
            set
            {
                _addReportCommand = value;
                OnPropertyChanged();
            }
        }

        private Report reportModel;
        public Report Report
        {
            get { return reportModel; }
            set
            {
                OnPropertyChanged();
                reportModel = value;
            }
        }

        public NewReportFormVM()
        {
            FormModel = new NewReportFormModel();
            this.reportModel = FormModel.Report.Clone() as Report;
            AddReportCommand = new RelayCommand<NewReportFormModel>(formModel =>
                {
                    formModel.Report = reportModel.Clone() as Report;
                    reportModel = new Report();
                    formModel.AddReport();
                },
                //if have more condition to add report 
                report => report != null);
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
