using Products_Managment_DataAccessLayer;
using System;
using System.Data;
using System.Data.SQLite;

public static class clsCategoryData
{
    public static DataTable GetAllCategories()
    {
        DataTable dt = new DataTable();

        using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
        {
            string query = "SELECT * FROM Categories";

            SQLiteCommand command = new SQLiteCommand(query, connection);

            try
            {
                connection.Open();
                SQLiteDataReader reader = command.ExecuteReader();
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

        using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
        {
            string query = "INSERT INTO Categories (CatDescription) VALUES (@CatDescription); SELECT last_insert_rowid();";

            using (SQLiteCommand command = new SQLiteCommand(query, connection))
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

        using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
        {
            string query = "UPDATE Categories SET CatDescription = @CatDescription WHERE CatID = @CatID";

            using (SQLiteCommand command = new SQLiteCommand(query, connection))
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

        using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
        {
            string query = "DELETE FROM Categories WHERE CatID = @CatID";

            using (SQLiteCommand command = new SQLiteCommand(query, connection))
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

        using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
        {
            string query = "SELECT * FROM Categories WHERE CatID = @CatID";

            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@CatID", CatID);

            try
            {
                connection.Open();
                SQLiteDataReader reader = command.ExecuteReader();

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
                // Handle exception
                Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }
        }

        return isFound;
    }

    public static bool FindCategoryByCatName(ref int CatID, string CatDescription)
    {
        bool isFound = false;

        using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
        {
            string query = "SELECT * FROM Categories WHERE CatDescription = @CatDescription";

            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@CatDescription", CatDescription);

            try
            {
                connection.Open();
                SQLiteDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;
                    CatID = (int)(long)(long)(reader["CatID"]);
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
                // Handle exception
                Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }
        }

        return isFound;
    }


    }

