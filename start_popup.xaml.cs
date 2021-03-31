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
using System.Windows.Shapes;

namespace WTF_WIKI_TRANS_FUN
{
    /// <summary>
    /// Interaktionslogik für start_popup.xaml
    /// </summary>
    public partial class start_popup : Window
    {
        public start_popup()
        {
            InitializeComponent();

            weiter_button.Click += new RoutedEventHandler(this.close_event);
           

        }
        
        private void close_event(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
