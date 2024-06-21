using Products_Managment_DataAccessLayer;
using System.Data;

namespace Product_Managment_BusniessLayer
{
    public class clsUser
    {

        private enum enMode { AddNew = 0, Update = 1 };
        enMode _Mode = enMode.AddNew;

        public int UserID { get; set; }
        public string Name { get; set;  }
        public string UserName { get; set; }
        public string Password { get; set; }

        public bool IsManager { set; get; }

        public clsUser()
        {
            this.UserID = -1;
            this.IsManager = true;
            this.Password = "";
            this.UserName = "";
            this.Name = ""; 
            _Mode = enMode.AddNew;

        }


        private clsUser(int userID,string name,  string userName, string password, bool IsManager)
        {
            _Mode = enMode.Update;
            this.UserID = userID;
            this.UserName = userName;
            this.Password = password;
            this.IsManager = IsManager;
            this.Name = name; 
        }


        private bool _AddNewUser()
        {
            this.UserID = clsUserData.AddNewUser(this.Name, this.UserName, this.Password, this.IsManager);
            return (UserID != -1);

        }

        private bool _UpdateUser()
        {
            return clsUserData.UpdateUser(this.UserID, this.UserName, this.Password, this.IsManager);

        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:

                    if (_AddNewUser())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }

                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateUser();
                default:
                    return false;
            }
        }

        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }

        public static clsUser FindUserByUserID (int UserID)
        {
            string Name = "";
            string UserName = "";
            string Password = "";
            bool IsManager = false;

            bool IsFound = (clsUserData.GetUserInfoByUserID(UserID,   ref Name, ref UserName, ref Password, ref IsManager));
            if (IsFound)
            {
                return new clsUser(UserID, Name, UserName, Password, IsManager);
            }
            else
            {
                return null;
            }
        }
        public static clsUser FindUserByUserNameAndPassword(string UserName, string Password)
        {
            int UserID = -1;
            string Name = "";
            bool IsManager = false;

            bool IsFound = (clsUserData.GetUserInfoByUsernameAndPassword(UserName, Password, ref UserID, ref Name , ref IsManager));
            if (IsFound)
            {
                return new clsUser(UserID,Name, UserName, Password, IsManager);
            }
            else
            {
                return null;
            }
        }
    }
}
