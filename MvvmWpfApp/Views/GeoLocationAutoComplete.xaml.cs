using MvvmWpfApp.ViewModels;
using System;
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

namespace MvvmWpfApp.Controls
{
    /// <summary>
    /// Interaction logic for GeoLocationAutoComplete.xaml
    /// </summary>
    public partial class GeoLocationAutoComplete : UserControl
    {
        public GeoLocationAutoCompleteVM CompleteVM { get; set; }
        public GeoLocationAutoComplete()
        {
            InitializeComponent();
            CompleteVM = new GeoLocationAutoCompleteVM();
            DataContext = CompleteVM;
        }

        private void AutoCompleteBox_OnTextChanged(object sender, RoutedEventArgs e)
        {
            CompleteVM.AutoComp(sender as AutoCompleteBox);
        }

    }
}
