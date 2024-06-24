using System;
using System.Data;
using System.Data.SQLite;

namespace Products_Managment_DataAccessLayer
{
    public class clsProductData
    {
        public static bool GetProductInfoByProductID(int ProductID, ref string ProductName,
           ref int Quantity, ref decimal Price, ref string ImageProduct, ref int CatID)
        {
            bool isFound = false;

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Products WHERE ProductID = @ProductID";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductID", ProductID);

                    try
                    {
                        connection.Open();
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                isFound = true;
                                ProductName = reader["ProductName"].ToString();
                                Quantity = Convert.ToInt32(reader["Quantity"]);
                                Price = Convert.ToDecimal(reader["Price"]);
                                ImageProduct = reader["ImageProduct"] != DBNull.Value ? reader["ImageProduct"].ToString() : "";
                                CatID = Convert.ToInt32(reader["CatID"]);
                            }
                            else
                            {
                                // The record was not found
                                isFound = false;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        isFound = false;
                    }
                }
            }

            return isFound;
        }

        public static bool GetProductInfoByProductNameAndPrice(string ProductName, decimal Price,
            ref int ProductID, ref int Quantity, ref string ImageProduct, ref int CatID)
        {
            bool isFound = false;

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Products WHERE ProductName = @ProductName and Price=@Price;";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductName", ProductName);
                    command.Parameters.AddWithValue("@Price", Price);

                    try
                    {
                        connection.Open();
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                isFound = true;
                                ProductID = Convert.ToInt32(reader["ProductID"]);
                                ProductName = reader["ProductName"].ToString();
                                Quantity = Convert.ToInt32(reader["Quantity"]);
                                Price = Convert.ToDecimal(reader["Price"]);
                                ImageProduct = reader["ImageProduct"] != DBNull.Value ? reader["ImageProduct"].ToString() : null;
                                CatID = Convert.ToInt32(reader["CatID"]);
                            }
                            else
                            {
                                // The record was not found
                                isFound = false;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        isFound = false;
                    }
                }
            }

            return isFound;
        }

        // this function will return the new product id if succeeded and -1 if not.
        public static int AddNewProduct(string ProductName, int Quantity, decimal Price, string ImageProduct, int CatID)
        {
            int ProductID = -1;

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "INSERT INTO Products (ProductName, Quantity, Price, ImageProduct, CatID) VALUES (@ProductName, @Quantity, @Price, @ImageProduct, @CatID); SELECT last_insert_rowid();";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductName", ProductName);
                    command.Parameters.AddWithValue("@Quantity", Quantity);
                    command.Parameters.AddWithValue("@Price", Price);
                    command.Parameters.AddWithValue("@ImageProduct", (object)ImageProduct ?? DBNull.Value);
                    command.Parameters.AddWithValue("@CatID", CatID);

                    try
                    {
                        connection.Open();
                        ProductID = Convert.ToInt32((long)command.ExecuteScalar());
                    }
                    catch (Exception)
                    {
                        ProductID = -1;
                    }
                }
            }

            return ProductID;
        }

        public static bool UpdateProduct(int ProductID, string ProductName, int Quantity, decimal Price, string ImageProduct, int CatID)
        {
            int rowsAffected = 0;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE Products  
                                 SET ProductName = @ProductName,
                                     Quantity = @Quantity,
                                     Price = @Price,
                                     ImageProduct = @ImageProduct,
                                     CatID = @CatID
                                 WHERE ProductID = @ProductID";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
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
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }

            return (rowsAffected > 0);
        }

        public static int GetProductQuantity(int ProductID)
        {
            int QuantityLeft = 0;

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT Quantity FROM Products WHERE ProductID = @ProductID";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductID", ProductID);

                    try
                    {
                        connection.Open();
                        QuantityLeft = Convert.ToInt32(command.ExecuteScalar());
                    }
                    catch (Exception)
                    {
                        QuantityLeft = 0;
                    }
                }
            }

            return QuantityLeft;
        }

        public static DataTable GetAllProducts()
        {
            DataTable dt = new DataTable();

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Products";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        // Handle exception
                    }
                }
            }

            return dt;
        }

        public static bool DeleteProduct(int ProductID)
        {
            int rowsAffected = 0;

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM Products WHERE ProductID = @ProductID";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductID", ProductID);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        // Handle exception
                    }
                }
            }

            return (rowsAffected > 0);
        }

        public static bool IsProductExist(int ProductID)
        {
            bool isFound = false;

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT 1 FROM Products WHERE ProductID = @ProductID";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductID", ProductID);

                    try
                    {
                        connection.Open();
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            isFound = reader.HasRows;
                        }
                    }
                    catch (Exception)
                    {
                        isFound = false;
                    }
                }
            }

            return isFound;
        }

        public static bool IsProductExist(string ProductName)
        {
            bool isFound = false;

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT 1 FROM Products WHERE ProductName = @ProductName";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductName", ProductName);

                    try
                    {
                        connection.Open();
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            isFound = reader.HasRows;
                        }
                    }
                    catch (Exception)
                    {
                        isFound = false;
                    }
                }
            }

            return isFound;
        }
    }
}
