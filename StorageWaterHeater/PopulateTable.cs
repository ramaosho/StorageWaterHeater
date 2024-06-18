using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Data.SqlClient;

namespace StorageWaterHeater
{
    class PopulateTable
    {
        public static void TestIDsCollection()
        {

            string CS = ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;
            string queryString = "SELECT [TABLE_NAME] FROM [StorageWaterHeater].[INFORMATION_SCHEMA].[TABLES] WHERE [TABLE_SCHEMA] = 'data' ORDER BY [TABLE_NAME] ASC";

            using SqlConnection connection = new(CS);

            SqlCommand command = new(queryString, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            // Call Read before accessing data.
            while (reader.Read())
            {
                //lstTestIDs.Items.Add(reader.GetString(0));
            }

            // Call Close when done reading.
            reader.Close();
        }
    }
}
