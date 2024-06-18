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
    /// Interaction logic for TestInformation.xaml
    /// </summary>
    public partial class TestInformation : Window
    {
        public TestInformation()
        {
            InitializeComponent();
        }

        private void winTestInformation_Closed(object sender, EventArgs e)
        {
            App.Current.MainWindow.Show();
        }
    }
}
