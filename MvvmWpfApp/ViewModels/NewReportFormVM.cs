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

        public RelayCommand<NewReportFormModel> AddReportCommand { get; } = 
            new RelayCommand<NewReportFormModel>(formModel =>
            {
                formModel.AddReport();
            },
            //if have more conditian to add report 
            report => report != null);


        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
