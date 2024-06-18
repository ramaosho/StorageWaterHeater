using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Data.SqlClient;

namespace StorageWaterHeater
{
    /// <summary>
    /// Interaction logic for GraphViewData.xaml
    /// </summary>
    public partial class GraphViewData : Window
    {
        public GraphViewData()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TglbtnIncludeZero_Checked(object sender, RoutedEventArgs e)
        {
            tglbtnIncludeZero.Content = "Zero Current Excluded";

            //tglbtnIncludeZero.Content = "Zero Current Included";
            //tglbtnIncludeZero.Background = Brushes.LightYellow;
        }

        private void TglbtnIncludeZero_Unchecked(object sender, RoutedEventArgs e)
        {

            tglbtnIncludeZero.Content = "Zero Current Included";

            //tglbtnIncludeZero.Content = "Zero Current Excluded";
            //tglbtnIncludeZero.Background = Brushes.DarkKhaki;
        }

        private void WinGraphView_Closed(object sender, EventArgs e)
        {
            App.Current.MainWindow.Show();
        }

        private void WinGraphView_Loaded(object sender, RoutedEventArgs e)
        {
            lstTestIDs.Items.Clear();
            string CS = ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;
            string queryString = "SELECT [TABLE_NAME] FROM [StorageWaterHeater].[INFORMATION_SCHEMA].[TABLES] WHERE [TABLE_SCHEMA] = 'data' ORDER BY [TABLE_NAME] ASC";

            using SqlConnection connection = new(CS);

            SqlCommand command = new(queryString, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            // Call Read before accessing data.
            while (reader.Read())
            {
                lstTestIDs.Items.Add(reader.GetString(0));
            }

            // Call Close when done reading.
            reader.Close();
        }
    }
}
