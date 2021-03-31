using System;
using System.Windows;

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