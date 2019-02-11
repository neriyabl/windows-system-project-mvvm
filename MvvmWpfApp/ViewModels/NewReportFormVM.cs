using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BE;
using MvvmWpfApp.Models;

namespace MvvmWpfApp.ViewModels
{
    public class NewReportFormVM : DependencyObject
    {
        private NewReportFormModel reportFormModel;
        public static readonly DependencyProperty reportModelProperty = DependencyProperty.Register(
            "reportModel", typeof(Report), typeof(NewReportFormVM), new PropertyMetadata(default(Report)));

        public Report reportModel
        {
            get { return (Report) GetValue(reportModelProperty); }
            set { SetValue(reportModelProperty, value); }
        }

        NewReportFormVM()
        {
            
        }
    }
}
