using System.Data.SqlClient;
using System;

namespace Products_Managment_DataAccessLayer
{
    public static class clsDataAccessSettings
    {
        static public string ConnectionString = "Server=.;Database=ProductsDB; User Id =sa; Password=123;Trusted_Connection=True;TrustServerCertificate=true;";


        public static bool RestoreDatabase(string backupFilePath)
        {

            bool isSuccess = false;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string restoreQuery = $@"
                    USE master;
                    ALTER DATABASE [ProductsDB] SET OFFLINE WITH ROLLBACK IMMEDIATE;
                    RESTORE DATABASE [ProductsDB] FROM DISK = @backupFilePath WITH REPLACE;
                    ALTER DATABASE [ProductsDB] SET MULTI_USER;";

                using (SqlCommand command = new SqlCommand(restoreQuery, connection))
                {
                    command.Parameters.AddWithValue("@backupFilePath", backupFilePath);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        isSuccess = true;
                    }
                    catch (Exception ex)
                    {
                        // Log the exception
                        // For example, you can log it to a file or event log
                        // LogException(ex);
                        isSuccess = false;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }

            return isSuccess;
        }
    }


}



