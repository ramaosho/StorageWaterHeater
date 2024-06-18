using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
    /// Interaction logic for StandingLossReport.xaml
    /// </summary>
    public partial class StandingLossReport : Window
    {
        public StandingLossReport()
        {
            InitializeComponent();
        }

        readonly string DatabaseName = "StorageWaterHeater";
        readonly string SchemaName = "data";
        string TableName = "";
        //string RecordsLimit = "1000";
        string ZeroAmpere = "";
        string OrderBy = "ASC";

        public void ShowDataGrid()
        {

            if (TableName != "")
            {
                string CS = ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;
                string query = "SELECT TOP (" + txtbxNumberOfRecords.Text.Trim() + ") [IndexID],[TimeStamp],[WaterTemperature],[InletTemperature],[OutletTemperature],[BodyTemperature],[AmbientTemperature],[FlowRateSV],[FlowRatePV],[FlowTotalizer],[Voltage],[Current],[Frequency],[PF],[Power],[EnergyWh],[LVTime],[Comments] FROM [" + DatabaseName + "].[" + SchemaName + "].[" + TableName + "] " + ZeroAmpere + " ORDER BY [IndexID] " + OrderBy + "";

                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgStandingLossReport.ItemsSource = dt.DefaultView;
                }
            }
            else
            {
                MessageBox.Show("TableName is empty!");
            }
        }

        private void WinStandingLossReport_Closed(object sender, EventArgs e)
        {
            App.Current.MainWindow.Show();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TglbtnOrder_Checked(object sender, RoutedEventArgs e)
        {
            tglbtnOrder.Content = "Descending Order";
            OrderBy = "DESC";
            ShowDataGrid();
        }

        private void TglbtnOrder_Unchecked(object sender, RoutedEventArgs e)
        {
            tglbtnOrder.Content = "Ascending Order";
            OrderBy = "ASC";
            ShowDataGrid();
        }

        private void TglbtnIncludeZero_Checked(object sender, RoutedEventArgs e)
        {
            tglbtnIncludeZero.Content = "Zero Excluded";
            ZeroAmpere = " WHERE [Current] <> 0 ";
            ShowDataGrid();
        }

        private void TglbtnIncludeZero_Unchecked(object sender, RoutedEventArgs e)
        {
            tglbtnIncludeZero.Content = "Zero Included";
            ZeroAmpere = String.Empty;
            ShowDataGrid();
        }

        private void BtnExportToExcel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LstTestIDs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstTestIDs.Items.Count > 0)
            {
                TableName = lstTestIDs.SelectedItem.ToString();
            }
        }

        private void WinStandingLossReport_Loaded(object sender, RoutedEventArgs e)
        {
            lstTestIDs.Items.Clear();

            string CS = ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;
            string queryString = "SELECT [name], [create_date], [SCHEMA_ID] FROM [StorageWaterHeater].[sys].[tables] WHERE [SCHEMA_ID] = 6 AND [name] LIKE '%" + txtbxSearchTestID.Text + "%' ORDER BY [create_date] DESC";

            using (SqlConnection connection = new(CS))
            {

                SqlCommand command = new SqlCommand(queryString, connection);

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

            if (lstTestIDs.Items.Count > 0)
            {
                lstTestIDs.SelectedIndex = 0;
                tglbtnOrder.IsEnabled = true;
                tglbtnIncludeZero.IsEnabled = true;
                btnExportToExcel.IsEnabled = true;
            }
            else
            {
                tglbtnOrder.IsEnabled = false;
                tglbtnIncludeZero.IsEnabled = false;
                btnExportToExcel.IsEnabled = false;
            }

        }

        private void LstTestIDs_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TableName = lstTestIDs.SelectedItem.ToString();
            ShowDataGrid();
        }

        private void TxtbxSearchTestID_TextChanged(object sender, TextChangedEventArgs e)
        {
            lstTestIDs.Items.Clear();

            string CS = ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;
            string queryString = "SELECT [name], [create_date], [SCHEMA_ID] FROM [StorageWaterHeater].[sys].[tables] WHERE [SCHEMA_ID] = 6 AND [name] LIKE '%" + txtbxSearchTestID.Text + "%' ORDER BY [create_date] DESC";

            using (SqlConnection connection = new(CS))
            {

                SqlCommand command = new SqlCommand(queryString, connection);

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

            if (lstTestIDs.Items.Count > 0)
            {
                lstTestIDs.SelectedIndex = 0;
                tglbtnOrder.IsEnabled = true;
                tglbtnIncludeZero.IsEnabled = true;
                btnExportToExcel.IsEnabled = true;
            }
            else
            {
                tglbtnOrder.IsEnabled = false;
                tglbtnIncludeZero.IsEnabled = false;
                btnExportToExcel.IsEnabled = false;
            }
        }

        private void TxtbxNumberOfRecords_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out int result);
        }


    }
}
