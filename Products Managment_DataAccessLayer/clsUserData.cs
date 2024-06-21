using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace Products_Managment_DataAccessLayer
{
    public class clsUserData
    {

        public static bool GetUserInfoByUserID(int UserID,ref string Name, ref string UserName,
           ref string Password, ref bool IsManager)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            SqlCommand command = new SqlCommand("SP_GetUserByUserID", connection);

            command.CommandType = CommandType.StoredProcedure; 
            command.Parameters.AddWithValue("@UserID", UserID);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;
                    Name = (string)reader["Name"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    IsManager = (bool)reader["IsManager"];


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

        public static bool GetUserInfoByUsernameAndPassword(string UserName, string Password,
            ref int UserID, ref string Name , ref bool IsManager)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            SqlCommand command = new SqlCommand("SP_GetUserByUserNameAndPassword", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("@Username", UserName);
            command.Parameters.AddWithValue("@Password", Password);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;
                    UserID = (int)reader["UserID"];
                    Name = (string)reader["Name"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    IsManager = (bool)reader["IsManager"];


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
                isFound = false; 
                //Console.WriteLine("Error: " + ex.Message);

            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static int AddNewUser(string Name, string UserName,
             string Password, bool IsManager)
        {
            //this function will return the new person id if succeeded and -1 if not.
            int UserID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);



            SqlCommand command = new SqlCommand("SP_AddNewUser", connection)
            {
                CommandType = CommandType.StoredProcedure
        };

            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsManager", IsManager);


            SqlParameter NewUserID = new SqlParameter("@NewUserID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            command.Parameters.Add(NewUserID);
            try
            {
                connection.Open();

                command.ExecuteNonQuery(); 

                if (NewUserID.Value != null )
                {
                    UserID = (int)NewUserID.Value;
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

            return UserID;
        }


        public static bool UpdateUser(int UserID, string UserName,
             string Password, bool IsManager)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  Users  
                            set  UserName = @UserName,
                                Password = @Password,
                                IsManager = @IsManager
                                where UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsManager", IsManager);
            command.Parameters.AddWithValue("@UserID", UserID);


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


        public static DataTable GetAllUsers()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            

            SqlCommand command = new SqlCommand("SP_GetAllUsers", connection);

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

        public static bool DeleteUser(int UserID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete Users 
                                where UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

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

        public static bool IsUserExist(int UserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Users WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

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

        public static bool IsUserExist(string UserName)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Users WHERE UserName = @UserName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserName", UserName);

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

        //// public static bool IsUserExistForPersonID(int PersonID)
        // {
        //     bool isFound = false;

        //     SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

        //     string query = "SELECT Found=1 FROM Users WHERE PersonID = @PersonID";

        //     SqlCommand command = new SqlCommand(query, connection);

        //     command.Parameters.AddWithValue("@PersonID", PersonID);

        //     try
        //     {
        //         connection.Open();
        //         SqlDataReader reader = command.ExecuteReader();

        //         isFound = reader.HasRows;

        //         reader.Close();
        //     }
        //     catch (Exception ex)
        //     {
        //         //Console.WriteLine("Error: " + ex.Message);
        //         isFound = false;
        //     }
        //     finally
        //     {
        //         connection.Close();
        //     }

        //     return isFound;
        // }

        //public static bool DoesPersonHaveUser44(int PersonID)
        //{
        //    bool isFound = false;

        //    SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

        //    string query = "SELECT Found=1 FROM Users WHERE PersonID = @PersonID";

        //    SqlCommand command = new SqlCommand(query, connection);

        //    command.Parameters.AddWithValue("@PersonID", PersonID);

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

        public static bool ChangePassword(int UserID, string NewPassword)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  Users  
                            set Password = @Password
                            where UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

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
    }
}
