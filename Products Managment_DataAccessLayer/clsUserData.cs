using System;
using System.Data;
using System.Data.SQLite;

namespace Products_Managment_DataAccessLayer
{
   

    public class clsUserData
    {
        public static bool GetUserInfoByUserID(int UserID, ref string Name, ref string UserName,
            ref string Password, ref bool IsManager)
        {
            bool isFound = false;

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Users WHERE UserID = @UserID";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", UserID);

                    try
                    {
                        connection.Open();
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                Name = reader["Name"].ToString();
                                UserName = reader["UserName"].ToString();
                                Password = reader["Password"].ToString();
                                IsManager = Convert.ToBoolean(reader["IsManager"]);
                            }
                            else
                            {
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

        public static bool GetUserInfoByUsernameAndPassword(string UserName, string Password,
            ref int UserID, ref string Name, ref bool IsManager)
        {
            bool isFound = false;

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Users WHERE UserName = @UserName AND Password = @Password";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Password", Password);

                    try
                    {
                        connection.Open();
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                UserID = Convert.ToInt32(reader["UserID"]);
                                Name = reader["Name"].ToString();
                                UserName = reader["UserName"].ToString();
                                Password = reader["Password"].ToString();
                                IsManager = Convert.ToBoolean(reader["IsManager"]);
                            }
                            else
                            {
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

        public static int AddNewUser(string Name, string UserName, string Password, bool IsManager)
        {
            int UserID = -1;

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "INSERT INTO Users (Name, UserName, Password, IsManager) VALUES (@Name, @UserName, @Password, @IsManager); SELECT last_insert_rowid();";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@IsManager", IsManager ? 1 : 0);

                    try
                    {
                        connection.Open();
                        UserID = Convert.ToInt32((long)command.ExecuteScalar());
                    }
                    catch (Exception)
                    {
                        UserID = -1;
                    }
                }
            }

            return UserID;
        }

        public static bool UpdateUser(int UserID, string UserName, string Password, bool IsManager)
        {
            int rowsAffected = 0;

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE Users  
                                 SET UserName = @UserName,
                                     Password = @Password,
                                     IsManager = @IsManager
                                 WHERE UserID = @UserID";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@IsManager", IsManager ? 1 : 0);
                    command.Parameters.AddWithValue("@UserID", UserID);

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

        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Users";
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

        public static bool DeleteUser(int UserID)
        {
            int rowsAffected = 0;

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM Users WHERE UserID = @UserID";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", UserID);

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

        public static bool IsUserExist(string UserName)
        {
            int result = 0;

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT COUNT(*) FROM Users WHERE UserName = @UserName";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", UserName);

                    try
                    {
                        connection.Open();
                        result = Convert.ToInt32((long)command.ExecuteScalar());
                    }
                    catch (Exception)
                    {
                        result = 0;
                    }
                }
            }

            return (result > 0);
        }

        public static bool IsUserExist(int UserID)
        {
            int result = 0;

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT COUNT(*) FROM Users WHERE UserID = @UserID";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", UserID);

                    try
                    {
                        connection.Open();
                        result = Convert.ToInt32((long)command.ExecuteScalar());
                    }
                    catch (Exception)
                    {
                        result = 0;
                    }
                }
            }

            return (result > 0);
        }

        public static bool ChangePassword(int UserID, string NewPassword)
        {
            int rowsAffected = 0;

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "UPDATE Users SET Password = @Password WHERE UserID = @UserID";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Password", NewPassword);
                    command.Parameters.AddWithValue("@UserID", UserID);

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
    }
}
