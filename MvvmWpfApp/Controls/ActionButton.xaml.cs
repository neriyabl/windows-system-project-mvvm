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
    /// Interaction logic for ActionButton.xaml
    /// </summary>
    public partial class ActionButton : UserControl
    {
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            "Text", typeof(String), typeof(ActionButton), new PropertyMetadata(default(String)));
        /// <summary>
        /// the text on the button
        /// </summary>
        public String Text
        {
            get { return (String) GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
            "Icon", typeof(String), typeof(ActionButton), new PropertyMetadata(default(String)));
        /// <summary>
        /// the icon in the button from material icons
        /// </summary>
        public String Icon
        {
            get { return (String) GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty StateProperty = DependencyProperty.Register(
            "State", typeof(String), typeof(ActionButton), new PropertyMetadata(default(String)));
        /// <summary>
        /// flat or origin
        /// </summary>
        public String State
        {
            get { return (String) GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly DependencyProperty StyleProperty = DependencyProperty.Register(
            "Style", typeof(Object), typeof(ActionButton), new PropertyMetadata(default(Object)));
        /// <summary>
        /// the material design style for button
        /// </summary>
        public Object Style
        {
            get { return (Object) GetValue(StyleProperty); }
            set { SetValue(StyleProperty, value); }
        }

        public event EventHandler ButtonClick;
        /// <summary>
        /// the click event
        /// </summary>
        /// <param name="sender">the button</param>
        /// <param name="e">event arguments</param>
        protected void Button_Click(object sender, EventArgs e)
        {
            //bubble the event up to the parent
            if (this.ButtonClick != null)
                this.ButtonClick(this, e);
        }

        public ActionButton()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
