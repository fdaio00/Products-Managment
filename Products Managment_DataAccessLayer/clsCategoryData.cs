using Products_Managment_DataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;


public static class clsCategoryData
{
    public static DataTable GetAllCategories()
    {
        DataTable dt = new DataTable();

        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            string query = "SELECT * FROM Categories";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);

                }
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine("Error: " + ex.Message);
            }
            finally

            {
                connection.Close();
            }
        }


        return dt;
    }

    public static int AddNewCategory(string catDescription)
    {
        int catID = -1;

        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            string query = "INSERT INTO Categories (CatDescription) VALUES (@CatDescription); SELECT SCOPE_IDENTITY();";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@CatDescription", catDescription);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    {
                        catID = insertedID;
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally

                {
                    connection.Close();
                }
            }
        }

        return catID;
    }

    public static bool UpdateCategory(int catID, string catDescription)
    {
        bool success = false;

        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            string query = "UPDATE Categories SET CatDescription = @CatDescription WHERE CatID = @CatID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@CatDescription", catDescription);
                command.Parameters.AddWithValue("@CatID", catID);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    success = rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    // Handle exception
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally

                {
                    connection.Close();
                }
            }
        }

        return success;
    }

    public static bool DeleteCategory(int catID)
    {
        bool success = false;

        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            string query = "DELETE FROM Categories WHERE CatID = @CatID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@CatID", catID);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    success = rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    // Handle exception
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally

                {
                    connection.Close();
                }
            }
        }

        return success;
    }

    public static bool FindCategoryByCatID(int CatID, ref string catDescription)
    {
        bool isFound = false;

        SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

        string query = "select * from Categories where CatID=@CatID";

        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@CatID", CatID);


        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                // The record was found
                isFound = true;
                catDescription = (string)reader["CatDescription"];

            }
            else
            {
                // The record was not found
                isFound = false;
            }

            reader.Close();
        }
        catch (Exception ex)
        {
            //Console.WriteLine("Error: " + ex.Message);
            isFound = false;
        }
        finally
        {
            connection.Close();
        }

        return isFound;
    }
    public static bool FindCategoryByCatName(ref int CatID, string CatDescription)
    {
        bool isFound = false;

        SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

        string query = "select * from Categories where CatDescription=@CatDescription";

        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@CatDescription", CatDescription);


        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                // The record was found
                isFound = true;
                CatID = (int)reader["CatID"];

            }
            else
            {
                // The record was not found
                isFound = false;
            }

            reader.Close();
        }
        catch (Exception ex)
        {
            //Console.WriteLine("Error: " + ex.Message);
            isFound = false;
        }
        finally
        {
            connection.Close();
        }

        return isFound;
    }

}
