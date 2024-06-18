using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StorageWaterHeater
{
    /// <summary>
    /// Interaction logic for FlowControlAutoManual.xaml
    /// </summary>
    public partial class FlowControlAutoManual : Window
    {
        public FlowControlAutoManual()
        {
            InitializeComponent();
        }

        private void winFlowControlAutoManual_Closed(object sender, EventArgs e)
        {
            App.Current.MainWindow.Show();
        }

        private void tbtnStation1_Checked(object sender, RoutedEventArgs e)
        {
            tbtnStation1.Content = "Manual";
        }

        private void tbtnStation1_Unchecked(object sender, RoutedEventArgs e)
        {
            tbtnStation1.Content = "Auto";
        }

        private void tbtnStation2_Checked(object sender, RoutedEventArgs e)
        {
            tbtnStation2.Content = "Manual";
        }

        private void tbtnStation2_Unchecked(object sender, RoutedEventArgs e)
        {
            tbtnStation2.Content = "Auto";
        }

        private void tbtnStation3_Checked(object sender, RoutedEventArgs e)
        {
            tbtnStation3.Content = "Manual";
        }

        private void tbtnStation3_Unchecked(object sender, RoutedEventArgs e)
        {
            tbtnStation3.Content = "Auto";
        }

        private void tbtnStation4_Checked(object sender, RoutedEventArgs e)
        {
            tbtnStation4.Content = "Manual";
        }

        private void tbtnStation4_Unchecked(object sender, RoutedEventArgs e)
        {
            tbtnStation4.Content = "Auto";
        }

        private void tbtnStation5_Checked(object sender, RoutedEventArgs e)
        {
            tbtnStation5.Content = "Manual";
        }

        private void tbtnStation5_Unchecked(object sender, RoutedEventArgs e)
        {
            tbtnStation5.Content = "Auto";
        }

        private void tbtnStation6_Checked(object sender, RoutedEventArgs e)
        {
            tbtnStation6.Content = "Manual";
        }

        private void tbtnStation6_Unchecked(object sender, RoutedEventArgs e)
        {
            tbtnStation6.Content = "Auto";
        }
    }
}
