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
using System.Configuration;
using System.Data;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;


namespace StorageWaterHeater
{
    /// <summary>
    /// Interaction logic for TableViewData.xaml
    /// </summary>
    public partial class TableViewData : Window
    {
        public TableViewData()
        {
            InitializeComponent();
        }

        string DatabaseName = "StorageWaterHeater";
        string SchemaName = "data";
        string TableName = "";
        string RecordsLimit = "1000";
        string ZeroAmpere = "";
        string OrderBy = "ASC";



        private void TglbtnOrder_Unchecked(object sender, RoutedEventArgs e)
        {
            tglbtnOrder.Content = "Ascending Order";
            OrderBy = "ASC";
            ShowDataGrid();

        }


        private void TglbtnOrder_Checked(object sender, RoutedEventArgs e)
        {

            tglbtnOrder.Content = "Descending Order";
            OrderBy = "DESC";
            ShowDataGrid();

        }


        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {

            this.Close();

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


        //private void lstTestIDs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //    TableName = lstTestIDs.SelectedItem.ToString();
        //}


        private void WinTableView_Closed(object sender, EventArgs e)
        {

            App.Current.MainWindow.Show();

        }


        public void ShowDataGrid()
        {

            if (TableName != "")
            {
                string CS = ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;
                string query = "SELECT TOP (" + txtbxNumberOfRecords.Text.Trim() + ") [IndexID],[TimeStamp],[WaterTemperature],[InletTemperature],[OutletTemperature],[BodyTemperature],[AmbientTemperature],[FlowRateSV],[FlowRatePV],[FlowTotalizer],[Voltage],[Current],[Frequency],[PF],[Power],[EnergyWh],[LVTime],[Comments] FROM [" + DatabaseName + "].[" + SchemaName + "].[" + TableName + "] " + ZeroAmpere + " ORDER BY [IndexID] " + OrderBy + "";
                //string query = "SELECT TOP (" + txtbxNumberOfRecords.Text.Trim() + ") * FROM [" + DatabaseName + "].[" + SchemaName + "].[" + TableName + "] " + ZeroAmpere + " ORDER BY [IndexID] " + OrderBy + "";

                //Server=localhost\SQLEXPRESS;Initial Catalog=StorageWaterHeater;Integrated Security=True;

                using SqlConnection con = new(CS);
                SqlCommand cmd = new SqlCommand(query, con);

                //con.Open();
                //SqlDataReader reader = cmd.ExecuteReader(); 
                //dgTableView.DataContext = reader;

                SqlDataAdapter da = new(cmd);
                DataTable dt = new();
                da.Fill(dt);
                dgTableView.ItemsSource = dt.DefaultView;
            }
            else
            {
                MessageBox.Show("TableName is empty!");
            }
        }


        private void LstTestIDs_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            TableName = lstTestIDs.SelectedItem.ToString();
            ShowDataGrid();           
        }


        private void TxtbxNumberOfRecords_TextChanged(object sender, TextChangedEventArgs e)
        {

            RecordsLimit = txtbxNumberOfRecords.Text;

        }


        private void TxtbxNumberOfRecords_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }


        private void WinTableView_Loaded(object sender, RoutedEventArgs e)
        {

            lstTestIDs.Items.Clear();
            string CS = ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;
            string queryString = "SELECT[name],[create_date] FROM [StorageWaterHeater].[sys].[tables] WHERE [SCHEMA_ID] = 6 AND [name] LIKE '%" + txtbxSearchTestID.Text +"%' ORDER BY [create_date] DESC";


            using SqlConnection connection = new(CS);
            SqlCommand command = new(queryString, connection);
            connection.Open();

            //connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            // Call Read before accessing data.
            while (reader.Read())
            {
                lstTestIDs.Items.Add(reader.GetString(0));
            }

            // Call Close when done reading.
            reader.Close();
        }

        private void TxtbxSearchTestID_TextChanged(object sender, TextChangedEventArgs e)
        {
            lstTestIDs.Items.Clear();
            string CS = ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;
            string queryString = "SELECT[name],[create_date] FROM [StorageWaterHeater].[sys].[tables] WHERE [SCHEMA_ID] = 6 AND [name] LIKE '%" + txtbxSearchTestID.Text + "%' ORDER BY [create_date] DESC";


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
