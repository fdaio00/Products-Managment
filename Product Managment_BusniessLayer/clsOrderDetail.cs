using Products_Managment_DataAccessLayer;
using System.Data;

namespace Product_Managment_BusniessLayer
{
    public class clsOrderDetail
    {
        private enum enMode { AddNew = 0, Update = 1 };
        enMode _Mode = enMode.AddNew;

        public int OrderDetailsID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }

        public float Price { get; set;  }

        public float Discount { get; set; } 

        public float Sum { get; set; }

        public float Total  { get; set; }


        public clsOrderDetail()
        {
            this.OrderDetailsID = -1;
            this.OrderID = -1;
            this.ProductID = -1;
            this.Quantity = 0;
            this.Price = 0;
            this.Total = 0;
            this.Discount = 0; 
            _Mode = enMode.AddNew;
        }

        public clsOrderDetail( int orderDetailsID, int orderID, int productID, int quantity, float price, float discount, float sum, float total)
        {
            _Mode = enMode.Update ;
            OrderDetailsID = orderDetailsID;
            OrderID = orderID;
            ProductID = productID;
            Quantity = quantity;
            Price = price;
            Discount = discount;
            Sum = sum;
            Total = total;
        }

      

        private bool _AddNewOrderDetails()
        {
            this.OrderDetailsID = clsOrderDetailData.AddNewOrderDetails(this.OrderID, this.ProductID, this.Quantity,this.Price, this.Discount, this.Sum, this.Total);
            return (OrderDetailsID != -1);
        }

        private bool _UpdateOrderDetails()
        {
            return clsOrderDetailData.UpdateOrderDetails(this.OrderDetailsID,this.OrderID, this.ProductID, this.Quantity, this.Price, this.Discount, this.Sum, this.Total);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewOrderDetails())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateOrderDetails();
                default:
                    return false;
            }
        }

        public static DataTable GetAllOrderDetails()
        {
            return clsOrderDetailData.GetAllOrderDetails();
        }
        public static DataTable GetOrderDetailsInfoByOrderIDForPrinting(int OrderID)
        {
            return clsOrderDetailData.GetOrderDetailsInfoByOrderIDForPrinting(OrderID);
        }

        public static DataTable GetOrderDetailsByOrderID(int OrderID)
        {
            return clsOrderDetailData.GetOrderDetailsInfoByOrderID(OrderID);
        }
    }

}
