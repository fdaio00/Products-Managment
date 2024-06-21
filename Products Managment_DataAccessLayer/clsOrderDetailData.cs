using System;
using System.Data;
using System.Data.SqlClient;

namespace Products_Managment_DataAccessLayer
{
    public class clsOrderDetailData
    {
        public static DataTable GetOrderDetailsInfoByOrderDetailsID(int OrderDetailsID)
        {
            DataTable dt = new DataTable();


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            SqlCommand command = new SqlCommand("SP_GetOrderDetailsByOrderDetailsID", connection);

            command.CommandType = CommandType.StoredProcedure; 

            command.Parameters.AddWithValue("@OrderDetailsID", OrderDetailsID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {


                    dt.Load(reader);
                    // The record was found
                    //isFound = true;
                    //OrderDetailsID = (int)reader["OrderDetailsID"];
                    //ProductID = (int)reader["ProductID"];
                    //Quantity = (int)reader["Quantity"];
                    //Price = (float)reader["Price"];
                    //Discount = (float)reader["Discount"];
                    //Sum = (int)reader["Sum"];
                    //Total = (int)reader["Total"];
                }
                else
                {
                    // The record was not found
                    dt = null;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                dt = null;
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static DataTable GetOrderDetailsInfoByOrderID(   int OrderID)
        {
            DataTable dt = new DataTable(); 

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            SqlCommand command = new SqlCommand("SP_GetOrderDetailsByOrderID", connection);

            command.CommandType = CommandType.StoredProcedure; 

            command.Parameters.AddWithValue("@OrderID", OrderID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {


                    dt.Load(reader);
                    // The record was found
                    //isFound = true;
                    //OrderDetailsID = (int)reader["OrderDetailsID"];
                    //ProductID = (int)reader["ProductID"];
                    //Quantity = (int)reader["Quantity"];
                    //Price = (float)reader["Price"];
                    //Discount = (float)reader["Discount"];
                    //Sum = (int)reader["Sum"];
                    //Total = (int)reader["Total"];
                }
                else
                {
                    // The record was not found
                    dt = null; 
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                dt = null; 
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }
        public static DataTable GetOrderDetailsInfoByOrderIDForPrinting(   int OrderID)
        {
            DataTable dt = new DataTable(); 

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            SqlCommand command = new SqlCommand("SP_GetOrderDetailsByOrderIDForPrint", connection);

            command.CommandType = CommandType.StoredProcedure; 

            command.Parameters.AddWithValue("@OrderID", OrderID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {


                    dt.Load(reader);
                    // The record was found
                    //isFound = true;
                    //OrderDetailsID = (int)reader["OrderDetailsID"];
                    //ProductID = (int)reader["ProductID"];
                    //Quantity = (int)reader["Quantity"];
                    //Price = (float)reader["Price"];
                    //Discount = (float)reader["Discount"];
                    //Sum = (int)reader["Sum"];
                    //Total = (int)reader["Total"];
                }
                else
                {
                    // The record was not found
                    dt = null; 
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                dt = null; 
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }
       

        public static int AddNewOrderDetails(  int OrderID,  int ProductID,  int Quantity,  float Price,  float Discount,  float Sum,  float Total)
        {
            //this function will return the new order details id if succeeded and -1 if not.
            int OrderDetailsID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            SqlCommand command = new SqlCommand("SP_AddOrderDetails", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@OrderID", OrderID);
            command.Parameters.AddWithValue("@ProductID", ProductID);
            command.Parameters.AddWithValue("@Quantity", Quantity);
            command.Parameters.AddWithValue("@Price", Price);
            command.Parameters.AddWithValue("@Discount", Discount);
            command.Parameters.AddWithValue("@Sum", Sum);
            command.Parameters.AddWithValue("@Total", Total);


            SqlParameter NewOrderDetailsID = new SqlParameter("@NewOrderDetailsID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            command.Parameters.Add(NewOrderDetailsID);

            try
            {
                connection.Open();

                command.ExecuteNonQuery();

                if (NewOrderDetailsID.Value!=null)
                {
                    OrderDetailsID = (int)NewOrderDetailsID.Value;
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return OrderDetailsID;
        }

        public static bool UpdateOrderDetails(int OrderDetailsID,  int OrderID, int ProductID,  int Quantity,  float Price,  float Discount,  float Sum,  float Total)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE OrderDetails  
                    SET OrderID = @OrderID,
                        ProductID = @ProductID,
                        Quantity = @Quantity
                    WHERE OrderDetailsID = @OrderDetailsID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@OrderID", OrderID);
            command.Parameters.AddWithValue("@ProductID", ProductID);
            command.Parameters.AddWithValue("@Quantity", Quantity);
            command.Parameters.AddWithValue("@OrderDetailsID", OrderDetailsID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static DataTable GetAllOrderDetails()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT OrderDetailsID, OrderID, ProductID, Quantity FROM OrderDetails";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static bool DeleteOrderDetails(int OrderDetailsID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"DELETE FROM OrderDetails 
                    WHERE OrderDetailsID = @OrderDetailsID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@OrderDetailsID", OrderDetailsID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static bool IsOrderDetailsExist(int OrderDetailsID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM OrderDetails WHERE OrderDetailsID = @OrderDetailsID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@OrderDetailsID", OrderDetailsID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

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

        public static bool IsOrderDetailsExist(int OrderID, int ProductID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM OrderDetails WHERE OrderID = @OrderID AND ProductID = @ProductID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@OrderID", OrderID);
            command.Parameters.AddWithValue("@ProductID", ProductID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

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
}
