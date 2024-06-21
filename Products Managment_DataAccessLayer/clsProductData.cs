using System;
using System.Data;
using System.Data.SqlClient;

namespace Products_Managment_DataAccessLayer
{
    public class clsProductData
    {



        public static bool GetProductInfoByProductID(int ProductID, ref string ProductName,
       ref int Quantity, ref decimal Price, ref string ImageProduct, ref int CatID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Products WHERE ProductID = @ProductID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ProductID", ProductID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;
                    ProductName = (string)reader["ProductName"];
                    Quantity = (int)reader["Quantity"];
                    Price = (decimal)reader["Price"];
                    ImageProduct = reader["ImageProduct"] != DBNull.Value ? (string)reader["ImageProduct"] : null;
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

        public static bool GetProductInfoByProductNameAndPrice(string ProductName, decimal Price,
            ref int ProductID, ref int Quantity, ref string ImageProduct, ref int CatID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Products WHERE ProductName = @ProductName and Price=@Price;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ProductName", ProductName);
            command.Parameters.AddWithValue("@Price", Price);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;
                    ProductID = (int)reader["ProductID"];
                    ProductName = (string)reader["ProductName"];
                    Quantity = (int)reader["Quantity"];
                    Price = (decimal)reader["Price"];
                    ImageProduct = reader["ImageProduct"] != DBNull.Value ? (string)reader["ImageProduct"] : null;
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

        
            //this function will return the new product id if succeeded and -1 if not.
            public static int AddNewProduct(string ProductName, int Quantity, decimal Price, string ImageProduct, int CatID)
            {

            int ProductID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand("SP_AddNewProduct", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("@ProductName", ProductName);
            command.Parameters.AddWithValue("@Quantity", Quantity);
            command.Parameters.AddWithValue("@Price", Price);
            command.Parameters.AddWithValue("@ImageProduct", (object)ImageProduct ?? DBNull.Value);
            command.Parameters.AddWithValue("@CatID", CatID);

            SqlParameter NewProductID = new SqlParameter("@NewProductID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            command.Parameters.Add(NewProductID);


            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                if(NewProductID.Value !=null)
                {
                    ProductID = (int)NewProductID.Value;
                }




            }

            catch(Exception ex )
            {

            }

            finally
            {
                connection.Close(); 
            }

            return ProductID; 
                // This function will return the new product ID if succeeded and -1 if not.
            //    int ProductID = -1;

            //    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            //    {
            //        SqlCommand command = new SqlCommand("SP_AddNewProduct", connection)
            //        {
            //            CommandType = CommandType.StoredProcedure
            //        };

            //        // Add input parameters
            //        command.Parameters.AddWithValue("@ProductName", ProductName);
            //        command.Parameters.AddWithValue("@Quantity", Quantity);
            //        command.Parameters.AddWithValue("@Price", Price);
            //        command.Parameters.AddWithValue("@ImageProduct", (object)ImageProduct ?? DBNull.Value);
            //        command.Parameters.AddWithValue("@CatID", CatID);

            //        // Add output parameter
            //        SqlParameter outputParam = new SqlParameter("@NewProductID", SqlDbType.Int)
            //        {
            //            Direction = ParameterDirection.Output
            //        };
            //        command.Parameters.Add(outputParam);

            //        try
            //        {
            //            connection.Open();

            //            command.ExecuteNonQuery();

            //            if (outputParam.Value != DBNull.Value)
            //            {
            //                ProductID = (int)outputParam.Value;
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            // Handle exception (e.g., log the error)
            //            // Console.WriteLine("Error: " + ex.Message);
            //        }
            //        finally
            //        {
            //            connection.Close();
            //        }
            //    }

            //    return ProductID;
            //}

        }

        public static bool UpdateProduct(int ProductID, string ProductName, int Quantity, decimal Price, string ImageProduct, int CatID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update Products  
                    set ProductName = @ProductName,
                        Quantity = @Quantity,
                        Price = @Price,
                        ImageProduct = @ImageProduct,
                        CatID = @CatID
                    where ProductID = @ProductID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ProductName", ProductName);
            command.Parameters.AddWithValue("@Quantity", Quantity);
            command.Parameters.AddWithValue("@Price", Price);
            command.Parameters.AddWithValue("@ImageProduct", (object)ImageProduct ?? DBNull.Value);
            command.Parameters.AddWithValue("@CatID", CatID);
            command.Parameters.AddWithValue("@ProductID", ProductID);

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


        public static int GetProductQuantity(int ProductID)
        {


            int QuantityLeft = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);



            SqlCommand command = new SqlCommand("SP_GetProductQuantity", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@ProductID", ProductID);

            SqlParameter QuantityNumber = new SqlParameter("@QuantityLeft", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(QuantityNumber);



            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                if (QuantityNumber.Value != null)
                {
                    QuantityLeft = Convert.ToInt32(QuantityNumber.Value);
                }
            }
            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return QuantityLeft;
        }
        public static DataTable GetAllProducts()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM ListProducts_View";

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
          public static DataTable GetValidProducts()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

     

            SqlCommand command = new SqlCommand("[SP_GetValidProducts]", connection);
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
        

        public static bool DeleteProduct(int ProductID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete Products 
                    where ProductID = @ProductID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ProductID", ProductID);

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

        public static bool IsProductExist(int ProductID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Products WHERE ProductID = @ProductID";

            SqlCommand command = new SqlCommand(query, connection);

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

        public static bool IsProductExist(string ProductName)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Products WHERE ProductName = @ProductName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ProductName", ProductName);

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
