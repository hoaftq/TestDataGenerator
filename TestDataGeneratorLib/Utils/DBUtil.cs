using System;
using System.Data.Odbc;

namespace TestDataGeneratorLib.Utils
{
    public static class DBUtil
    {
        public static bool TestConnection(string connectionString, out string errorMessage)
        {
            using (var connection = new OdbcConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    errorMessage = ex.ToString();
                    return false;
                }
            }

            errorMessage = string.Empty;
            return true;
        }
    }
}
