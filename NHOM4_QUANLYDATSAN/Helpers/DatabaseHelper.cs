using System;
using System.Configuration;
using System.Data.SqlClient;

namespace NHOM4_QUANLYDATSAN.Helpers
{
    public static class DatabaseHelper
    {
       private static readonly string connectionString = ConfigurationManager.ConnectionStrings["SportsBookingContext"].ConnectionString;

        public static SqlConnection GetConnection()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while opening the database connection: " + ex.Message);
            }
        }

        public static void CloseConnection(SqlConnection connection)
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}