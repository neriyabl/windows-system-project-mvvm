using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BE;
using BL;
using MvvmWpfApp.Utils;

namespace MvvmWpfApp.Models
{
    public class NewReportFormModel
    {
        private readonly IBl _bl = new FactoryBl().GetInstance();

        public Report Report { get; set; } = new Report();

        public void AddReport()
        {
            _bl.AddReport(Report);
        }

    }
}
