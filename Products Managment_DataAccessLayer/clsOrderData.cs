using System;
using System.Data;
using System.Data.SqlClient;

namespace Products_Managment_DataAccessLayer
{
    public class clsOrderData
    {

        public static bool GetOrderInfoByOrderID(int OrderID, ref DateTime OrderDate, ref string OrderDescription
            , ref int CustomerID , ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

           

            SqlCommand command = new SqlCommand("SP_GetOrderByOrderID", connection);
            command.CommandType = CommandType.StoredProcedure; 

            command.Parameters.AddWithValue("@OrderID", OrderID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;
                    OrderDate = (DateTime)reader["OrderDate"];
                    OrderDescription = (string)reader["OrderDescription"];
                    CustomerID = (int)reader["CustomerID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
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

        //public static bool GetOrderInfoByOrderDateAndCustomerID(DateTime OrderDate, int CustomerID,
        //    ref int OrderID)
        //{
        //    bool isFound = false;

        //    SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

        //    string query = "SELECT * FROM Orders WHERE OrderDate = @OrderDate and CustomerID=@CustomerID;";

        //    SqlCommand command = new SqlCommand(query, connection);

        //    command.Parameters.AddWithValue("@OrderDate", OrderDate);
        //    command.Parameters.AddWithValue("@CustomerID", CustomerID);

        //    try
        //    {
        //        connection.Open();
        //        SqlDataReader reader = command.ExecuteReader();

        //        if (reader.Read())
        //        {
        //            // The record was found
        //            isFound = true;
        //            OrderID = (int)reader["OrderID"];
        //        }
        //        else
        //        {
        //            // The record was not found
        //            isFound = false;
        //        }

        //        reader.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        //Console.WriteLine("Error: " + ex.Message);
        //        isFound = false;
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }

        //    return isFound;
        //}

        public static bool AddNewOrder( int OrderID, DateTime OrderDate, string OrderDescription,  int CustomerID , int CreatedByUserID)
        {
            //this function will return the new order id if succeeded and -1 if not.
           int  rowsAffected =0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

         

            SqlCommand command = new SqlCommand("SP_AddNewOrder", connection);
            command.CommandType = CommandType.StoredProcedure;


            command.Parameters.AddWithValue("@OrderID", OrderID);
            command.Parameters.AddWithValue("@OrderDate", OrderDate);
            command.Parameters.AddWithValue("@OrderDescription", OrderDescription);
            command.Parameters.AddWithValue("@CustomerID", CustomerID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

           

            try
            {
                connection.Open();

                rowsAffected=  command.ExecuteNonQuery();

             
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected>0);
        }

      public static int GetNewOrderNumber( )
        {
            //this function will return the new order id if succeeded and -1 if not.
            int NewOrderNumber = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

         

            SqlCommand command = new SqlCommand("SP_GetLastOrderNo", connection);

            command.CommandType = CommandType.StoredProcedure; 

            

            try
            {
                connection.Open();

                 object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int OrderNO))
                {
                    NewOrderNumber = OrderNO;
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

            return NewOrderNumber;
        }

        public static bool UpdateOrder(int OrderID, DateTime OrderDate, string OrderDescription, int CustomerID, int CreatedByUserID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

           

            SqlCommand command = new SqlCommand("SP_UpdateOrder", connection);
            command.CommandType = CommandType.StoredProcedure; 

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
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static DataTable GetAllOrders()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            SqlCommand command = new SqlCommand("SP_GetAllOrders", connection);
            command.CommandType = CommandType.StoredProcedure; 

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

        public static bool DeleteOrder(int OrderID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

           

            SqlCommand command = new SqlCommand("SP_DeleteOrder", connection);
            command.CommandType = CommandType.StoredProcedure; 

            command.Parameters.AddWithValue("@OrderID", OrderID);

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

       

        //public static bool IsOrderExist(int OrderID)
        //{
        //    bool isFound = false;

        //    SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

        //    string query = "SELECT Found=1 FROM Orders WHERE OrderID = @OrderID";

        //    SqlCommand command = new SqlCommand(query, connection);

        //    command.Parameters.AddWithValue("@OrderID", OrderID);

        //    try
        //    {
        //        connection.Open();
        //        SqlDataReader reader = command.ExecuteReader();

        //        isFound = reader.HasRows;

        //        reader.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        //Console.WriteLine("Error: " + ex.Message);
        //        isFound = false;
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }

        //    return isFound;
        //}

        //public static bool IsOrderExist(DateTime OrderDate, int CustomerID)
        //{
        //    bool isFound = false;

        //    SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

        //    string query = "SELECT Found=1 FROM Orders WHERE OrderDate = @OrderDate AND CustomerID = @CustomerID";

        //    SqlCommand command = new SqlCommand(query, connection);

        //    command.Parameters.AddWithValue("@OrderDate", OrderDate);
        //    command.Parameters.AddWithValue("@CustomerID", CustomerID);

        //    try
        //    {
        //        connection.Open();
        //        SqlDataReader reader = command.ExecuteReader();

        //        isFound = reader.HasRows;

        //        reader.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        //Console.WriteLine("Error: " + ex.Message);
        //        isFound = false;
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }

        //    return isFound;
        //}

    }
}
