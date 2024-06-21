using Products_Managment_DataAccessLayer;
using System;
using System.Data;

namespace Product_Managment_BusniessLayer
{
    public class clsOrder

    {


        public enum enMode { AddNew = 0, Update = 1 };
        enMode Mode = enMode.AddNew;

        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }

        public string OrderDescription { get; set; }

        public int CustomerID { get; set; }

        public clsCustomer CustomerInfo { get; set; }

        public int CreatedByUserID { get; set; }

        public clsUser CreatedUserInfo { get; set; }
        public clsOrder()
        {
            this.OrderID = -1;
            this.OrderDate = DateTime.Now;
            this.CustomerID = -1;
            this.OrderDescription = "";
            this.CreatedByUserID = -1;
            Mode = enMode.AddNew;
        }

        private clsOrder(int orderID, DateTime orderDate, string orderDescription, int customerID, int createdByUserID)
        {
            Mode = enMode.Update;
            this.OrderID = orderID;
            this.OrderDate = orderDate;
            this.OrderDescription = orderDescription;
            this.CustomerID = customerID;
            this.CustomerInfo = clsCustomer.FindCustomerByCustomerID(this.CustomerID);
            this.CreatedByUserID = createdByUserID;
            this.CreatedUserInfo = clsUser.FindUserByUserID(this.CreatedByUserID);
        }

        private bool _AddNewOrder()
        {
            return clsOrderData.AddNewOrder(this.OrderID, this.OrderDate, this.OrderDescription, this.CustomerID, this.CreatedByUserID);

        }

        private bool _UpdateOrder()
        {
            return clsOrderData.UpdateOrder(this.OrderID, this.OrderDate, this.OrderDescription, this.CustomerID, this.CreatedByUserID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewOrder())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateOrder();
                default:
                    return false;
            }
        }

        public static int GetNewOrderNumber()
        {
            return clsOrderData.GetNewOrderNumber();
        }

        public static DataTable GetAllOrders()
        {
            return clsOrderData.GetAllOrders();
        }

        public static clsOrder FindOrderByOrderID(int orderID)
        {
            DateTime OrderDate = DateTime.Now;
            string OrderDescription = "";
            int CustomerID = -1;
            int CreatedByUserID = -1;

            bool IsFound = clsOrderData.GetOrderInfoByOrderID(orderID, ref OrderDate, ref OrderDescription, ref CustomerID, ref CreatedByUserID);

            if(IsFound )
            {
                return new clsOrder(orderID, OrderDate, OrderDescription, CustomerID, CreatedByUserID);
            }
            else
            {
                return null; 
            }
        }
    }

}
