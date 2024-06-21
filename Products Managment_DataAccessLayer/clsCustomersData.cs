using Products_Managment_DataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;

public static class clsCustomerData
{
    public static DataTable GetAllCustomers()
    {
        DataTable dt = new DataTable();

        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
           

            using (SqlCommand command = new SqlCommand("SP_GetAllCustomers", connection))
            {
                command.CommandType = CommandType.StoredProcedure; 
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if(reader.HasRows)
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

        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            string query = "INSERT INTO Customers (FirstName, LastName, Phone, Email, ImagePath) VALUES (@FirstName, @LastName, @Phone, @Email, @ImagePath); SELECT SCOPE_IDENTITY();";

            using (SqlCommand command = new SqlCommand(query, connection))
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

        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            string query = "UPDATE Customers SET FirstName = @FirstName, LastName = @LastName, Phone = @Phone, Email = @Email, ImagePath = @ImagePath WHERE CustomerID = @CustomerID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@Phone", phone);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@ImagePath", imagePath);
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

        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {

            using (SqlCommand command = new SqlCommand("SP_DeleteCustomerByID", connection))

            {
                command.CommandType = CommandType.StoredProcedure; 
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

    public static bool GetCustomerByID(int customerID, ref string FirstName , ref string LastName, ref string Phone, ref string Email,
        ref string ImagePath)
    {
        bool IsFound = false; 

        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            

            using (SqlCommand command = new SqlCommand("SP_GetCustomerByCustomerID", connection))
            {

                command.CommandType = CommandType.StoredProcedure; 

                command.Parameters.AddWithValue("@CustomerID", customerID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        IsFound = true; 
                        customerID =  (int)reader["CustomerID"];
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
            }
        }

        return IsFound; 
    }

  
}
