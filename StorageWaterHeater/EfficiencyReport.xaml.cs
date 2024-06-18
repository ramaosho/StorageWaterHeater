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
    /// Interaction logic for EfficiencyReport.xaml
    /// </summary>
    public partial class EfficiencyReport : Window
    {
        public EfficiencyReport()
        {
            InitializeComponent();
        }

        private void winEfficiencyReport_Closed(object sender, EventArgs e)
        {
            App.Current.MainWindow.Show();
        }
    }
}
