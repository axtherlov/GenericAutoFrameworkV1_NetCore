using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace AutoFramework.Helpers
{
    public static class DataHelperExtensions
    {
        public static SqlConnection DBConnect(this SqlConnection sqlConnection, string connectionString)
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
            }
            catch (Exception e)
            {
                
            }

            return sqlConnection;
        }

        public static void DBClose(this SqlConnection sqlConnection)
        {
            try
            {
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                
            }
        }

        public static DataTable ExecuteQuery(this SqlConnection sqlConnection, string queryString)
        {
            DataSet dataset;
            try
            {
                if (sqlConnection == null || sqlConnection != null && 
                    (sqlConnection.State == ConnectionState.Closed ||
                     sqlConnection.State == ConnectionState.Broken ))
                {
                    sqlConnection.Open();

                    var dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = new SqlCommand(queryString, sqlConnection);
                    dataAdapter.SelectCommand.CommandType = CommandType.Text;

                    dataset = new DataSet();
                    dataAdapter.Fill(dataset, "table");
                    sqlConnection.Close();
                    return dataset.Tables["table"];
                }
            }
            catch (Exception e)
            {
                dataset = null;
                sqlConnection.Close();
                //LogHelpers.Write($"ERROR :: {e.Message}");
            }

            return null;
        }
    }
}
