#pragma checksum "..\..\..\Views\NewReportFormView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "549F336F95838A69B55E231ABECD71E2A36273DC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BE;
using MvvmWpfApp.Views;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace MvvmWpfApp.Views
{


    /// <summary>
    /// NewReportFormView
    /// </summary>
    public partial class NewReportFormView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector
    {


#line 15 "..\..\..\Views\NewReportFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid1;

#line default
#line hidden


#line 39 "..\..\..\Views\NewReportFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker timeDatePicker;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MvvmWpfApp;component/views/newreportformview.xaml", System.UriKind.Relative);

#line 1 "..\..\..\Views\NewReportFormView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:

#line 9 "..\..\..\Views\NewReportFormView.xaml"
                    ((MvvmWpfApp.Views.NewReportFormView)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);

#line default
#line hidden
                    return;
                case 2:
                    this.grid1 = ((System.Windows.Controls.Grid)(target));
                    return;
                case 3:
                    this.AddressTextBox = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 4:
                    this.AgeTextBox = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 5:
                    this.NameTextBox = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 6:
                    this.NoiseIntensityTextBox = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 7:
                    this.NumOfExplosionsTextBox = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 8:
                    this.timeDatePicker = ((System.Windows.Controls.DatePicker)(target));
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.TextBox AddressTextBox;
        internal System.Windows.Controls.TextBox AgeTextBox;
        internal System.Windows.Controls.TextBox NameTextBox;
        internal System.Windows.Controls.TextBox NoiseIntensityTextBox;
        internal System.Windows.Controls.TextBox NumOfExplosionsTextBox;
    }
}

