using System;
using System.Data;
using System.Data.SQLite;

namespace Products_Managment_DataAccessLayer
{
    public class clsOrderData
    {
        public static bool GetOrderInfoByOrderID(int OrderID, ref DateTime OrderDate, ref string OrderDescription, ref int CustomerID, ref int CreatedByUserID)
        {
            bool isFound = false;

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                SQLiteCommand command = new SQLiteCommand("SELECT * FROM Orders WHERE OrderID = @OrderID", connection);
                command.Parameters.AddWithValue("@OrderID", OrderID);

                try
                {
                    connection.Open();
                    SQLiteDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        isFound = true;
                        OrderDate = (DateTime)reader["OrderDate"];
                        OrderDescription = (string)reader["OrderDescription"];
                        CustomerID = (int)reader["CustomerID"];
                        CreatedByUserID = (int)reader["CreatedByUserID"];
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    isFound = false;
                }
            }

            return isFound;
        }

        public static bool AddNewOrder(int OrderID, DateTime OrderDate, string OrderDescription, int CustomerID, int CreatedByUserID)
        {
            int rowsAffected = 0;

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "INSERT INTO Orders (OrderID, OrderDate, OrderDescription, CustomerID, CreatedByUserID) VALUES (@OrderID, @OrderDate, @OrderDescription, @CustomerID, @CreatedByUserID)";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@OrderID", OrderID);
                command.Parameters.AddWithValue("@OrderDate", OrderDate);
                command.Parameters.AddWithValue("@OrderDescription", OrderDescription);
                command.Parameters.AddWithValue("@CustomerID", CustomerID);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return (rowsAffected > 0);
        }

        public static int GetNewOrderNumber()
        {
            int newOrderNumber = -1;

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT COALESCE(MAX(OrderID), 0) + 1 FROM Orders";

                SQLiteCommand command = new SQLiteCommand(query, connection);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int orderNO))
                    {
                        newOrderNumber = orderNO;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return newOrderNumber;
        }

        public static bool UpdateOrder(int OrderID, DateTime OrderDate, string OrderDescription, int CustomerID, int CreatedByUserID)
        {
            int rowsAffected = 0;

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "UPDATE Orders SET OrderDate = @OrderDate, OrderDescription = @OrderDescription, CustomerID = @CustomerID, CreatedByUserID = @CreatedByUserID WHERE OrderID = @OrderID";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@OrderID", OrderID);
                command.Parameters.AddWithValue("@OrderDate", OrderDate);
                command.Parameters.AddWithValue("@OrderDescription", OrderDescription);
                command.Parameters.AddWithValue("@CustomerID", CustomerID);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }

            return (rowsAffected > 0);
        }

        public static DataTable GetAllOrders()
        {
            DataTable dt = new DataTable();

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Orders";

                SQLiteCommand command = new SQLiteCommand(query, connection);

                try
                {
                    connection.Open();
                    SQLiteDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        dt.Load(reader);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return dt;
        }

        public static bool DeleteOrder(int OrderID)
        {
            int rowsAffected = 0;

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM Orders WHERE OrderID = @OrderID";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@OrderID", OrderID);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return (rowsAffected > 0);
        }
    }
}
