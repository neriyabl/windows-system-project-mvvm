using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BE;
using BL;

namespace MvvmWpfApp.Models
{
    class NewReportFormModel: ICommand
    {
        private IBl bl = new FactoryBl().GetInstance();

        public Report Report { get; set; }


        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }

        public event EventHandler CanExecuteChanged;
    }
}
