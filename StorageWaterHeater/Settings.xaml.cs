using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using Microsoft.Win32;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace StorageWaterHeater
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
            //DispatcherTimer timer = new DispatcherTimer();
            //timer.Interval = TimeSpan.FromSeconds(1);
            //timer.Tick += timer_Tick;
            //timer.Start();
        }
        void Timer_Tick(object sender, EventArgs e)
        {
            //lstbxRama.ItemsSource = ProcessData.TemperatureArray;
        }

        private void WinSettings_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //txtblkWindowHeight.Text = winSettings.ActualHeight.ToString();
            //txtblkWindowWidth.Text = winSettings.ActualWidth.ToString();
        }

        private void WinSettings_Closed(object sender, EventArgs e)
        {
            App.Current.MainWindow.Show();
        }

        private void ButtonSelectPath_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new();
            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtbxDataPath.Text = folderBrowserDialog.SelectedPath;
            }
            else
            {
                txtbxDataPath.Text = @"D:\Datalogging";
            }

        }

        private void WinSettings_Loaded(object sender, RoutedEventArgs e)
        {
            txtbxIntervalSeconds.Focus();
        }

        private void WinSettings_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        private void TxtbxIntervalSeconds_TextChanged(object sender, TextChangedEventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;
            string query = "UPDATE [StorageWaterHeater].[appsettings].[AppSettings] SET [LoggingIntervalSeconds] = " + txtbxIntervalSeconds.Text + " "; // update set query

            using SqlConnection con = new SqlConnection(CS);
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();

        }

        private void TxtbxIntervalSeconds_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out int result);
        }

        private void TxtbxPLCIP_TextChanged(object sender, TextChangedEventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;
            string query = "UPDATE [StorageWaterHeater].[appsettings].[AppSettings] SET [FlowControlPLCIP] = '" + txtbxPLCIP.Text + "' "; // update set query

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
