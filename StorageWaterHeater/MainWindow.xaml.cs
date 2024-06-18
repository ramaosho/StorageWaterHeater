using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Threading;

namespace StorageWaterHeater
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Content = DateTime.Now.ToLongTimeString();
            SimulatedData.GetLiveTable();

            //Tabulator tabulator = new Tabulator();
            //dgDashboard.ItemsSource = tabulator.rowItems;
            //ProcessData.LiveTableView();            

            dgDashboard.ItemsSource = SimulatedData.GetLiveTable();
        }



        private void winHome_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult response = MessageBox.Show("Do you really want to Exit?", "Exit Confirmation!", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (response == MessageBoxResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnTable_Click(object sender, RoutedEventArgs e)
        {
            TableViewData tableViewData = new TableViewData();
            this.Hide();
            tableViewData.Show();
        }

        private void btnGraph_Click(object sender, RoutedEventArgs e)
        {
            GraphViewData graphViewData = new GraphViewData();
            this.Hide();
            graphViewData.Show();
        }

        private void btnTestStation01_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnTestStation02_Click(object sender, RoutedEventArgs e)
        {


        }

        private void btnTestInformation_Click(object sender, RoutedEventArgs e)
        {
            TestInformation testInformation = new TestInformation();
            this.Hide();
            testInformation.Show();
        }

        private void btnEfficiencyReport_Click(object sender, RoutedEventArgs e)
        {
            EfficiencyReport efficiencyReport = new EfficiencyReport();
            this.Hide();
            efficiencyReport.Show();
        }

        private void btnStandingLossReport_Click(object sender, RoutedEventArgs e)
        {
            StandingLossReport standingLossReport = new StandingLossReport();
            this.Hide();
            standingLossReport.Show();
        }

        private void btnFlowControlAutoManual_Click(object sender, RoutedEventArgs e)
        {
            FlowControlAutoManual flowControlAutoManual = new FlowControlAutoManual();
            this.Hide();
            flowControlAutoManual.Show();
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings();
            this.Hide();
            settings.Show();
        }


        private void winHome_Loaded(object sender, RoutedEventArgs e)
        {
            //int[,] myarray = new int[6, 6];
            //myarray[0, 0] = 35;
            //dgLiveData.ItemsSource = myarray;
        }
    }
}
