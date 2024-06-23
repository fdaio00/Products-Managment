using System;
using System.Data;
using System.Data.SQLite;

namespace Products_Managment_DataAccessLayer
{
    public static class clsCustomerData
    {
        public static DataTable GetAllCustomers()
        {
            DataTable dt = new DataTable();

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Customers"; // Adjust query if using stored procedures or views

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SQLiteDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                            dt.Load(reader);
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

            return dt;
        }

        public static int AddNewCustomer(string firstName, string lastName, string phone, string email, string imagePath)
        {
            int customerID = -1;

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "INSERT INTO Customers (FirstName, LastName, Phone, Email, ImagePath) VALUES (@FirstName, @LastName, @Phone, @Email, @ImagePath); SELECT last_insert_rowid();";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@ImagePath", (object)imagePath ?? DBNull.Value);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            customerID = insertedID;
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

            return customerID;
        }

        public static bool UpdateCustomer(int customerID, string firstName, string lastName, string phone, string email, string imagePath)
        {
            bool success = false;

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "UPDATE Customers SET FirstName = @FirstName, LastName = @LastName, Phone = @Phone, Email = @Email, ImagePath = @ImagePath WHERE CustomerID = @CustomerID";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@ImagePath", (object)imagePath ?? DBNull.Value);
                    command.Parameters.AddWithValue("@CustomerID", customerID);

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

        public static bool DeleteCustomer(int customerID)
        {
            bool success = false;

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM Customers WHERE CustomerID = @CustomerID";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerID", customerID);

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

        public static bool GetCustomerByID(int customerID, ref string FirstName, ref string LastName, ref string Phone, ref string Email, ref string ImagePath)
        {
            bool isFound = false;

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Customers WHERE CustomerID = @CustomerID";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerID", customerID);

                    try
                    {
                        connection.Open();
                        SQLiteDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            isFound = true;
                            FirstName = reader["FirstName"].ToString();
                            LastName = reader["LastName"].ToString();
                            Phone = reader["Phone"].ToString();
                            Email = reader["Email"].ToString();
                            ImagePath = reader["ImagePath"] != DBNull.Value ? reader["ImagePath"].ToString() : "";
                        }
                        reader.Close();
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

            return isFound;
        }
    }
}
