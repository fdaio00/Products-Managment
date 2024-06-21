using System.Data;

public class clsCustomer
{
    private enum enMode { AddNew = 0, Update = 1 };
    enMode _Mode = enMode.AddNew;

    public int CustomerID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string ImagePath { get; set; }

    public clsCustomer()
    {
        this.CustomerID = -1;
        this.FirstName = "";
        this.LastName = "";
        this.Phone = "";
        this.Email = "";
        this.ImagePath = "";
        _Mode = enMode.AddNew;
    }

    private clsCustomer(int customerID, string firstName, string lastName, string phone, string email, string imagePath)
    {
        _Mode = enMode.Update;
        this.CustomerID = customerID;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Phone = phone;
        this.Email = email;
        this.ImagePath = imagePath;
    }

    private bool _AddNewCustomer()
    {
        this.CustomerID = clsCustomerData.AddNewCustomer(this.FirstName, this.LastName, this.Phone, this.Email, this.ImagePath);
        return (this.CustomerID != -1);
    }

    private bool _UpdateCustomer()
    {
        return clsCustomerData.UpdateCustomer(this.CustomerID, this.FirstName, this.LastName, this.Phone, this.Email, this.ImagePath);
    }

    public bool Save()
    {
        switch (_Mode)
        {
            case enMode.AddNew:
                if (_AddNewCustomer())
                {
                    _Mode = enMode.Update;
                    return true;
                }
                else
                {
                    return false;
                }
            case enMode.Update:
                return _UpdateCustomer();
            default:
                return false;
        }
    }

    public static DataTable GetAllCustomers()
    {
        return clsCustomerData.GetAllCustomers();
    }

    public static clsCustomer FindCustomerByCustomerID(int customerID)
    {
        string FirstName = "";   
        string LastName = "";   
        string Phone = "";   
        string Email = "";   
        string ImagePath = "";

        bool IsFound = clsCustomerData.GetCustomerByID(customerID, ref FirstName, ref LastName, ref Phone, ref Email, ref ImagePath);
        if (IsFound)
        {

            return new clsCustomer(customerID, FirstName, LastName, Phone, Email, ImagePath);
        }
         else  
        return null;
    }

    public static bool DeleteByCustomerID(int CustomerID)
    {
        return clsCustomerData.DeleteCustomer(CustomerID);
    }
}
