using Products_Managment_DataAccessLayer;
using System.Data;

namespace Product_Managment_BusniessLayer
{
    public class clsProduct
    {
        private enum enMode { AddNew = 0, Update = 1 };
        enMode _Mode = enMode.AddNew;

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string ImageProduct { get; set; }
        public int CatID { get; set; }

        public clsProduct()
        {
            this.ProductID = -1;
            this.ProductName = "";
            this.Quantity = 0;
            this.Price = 0;
            this.ImageProduct = "";
            this.CatID = -1;
            _Mode = enMode.AddNew;
        }

        private clsProduct(int productID, string productName, int quantity, decimal price, string imageProduct, int catID)
        {
            _Mode = enMode.Update;
            ProductID = productID;
            ProductName = productName;
            Quantity = quantity;
            Price = price;
            ImageProduct = imageProduct;
            CatID = catID;
        }

        private bool _AddNewProduct()
        {
            this.ProductID = clsProductData.AddNewProduct(this.ProductName, this.Quantity, this.Price, this.ImageProduct, this.CatID);
            return (this.ProductID != -1);
        }

        private bool _UpdateProduct()
        {
            return clsProductData.UpdateProduct(this.ProductID, this.ProductName, this.Quantity, this.Price, this.ImageProduct, this.CatID);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewProduct())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateProduct();
                default:
                    return false;
            }
        }

        public static DataTable GetAllProducts()
        {
            return clsProductData.GetAllProducts();
        }

        //public static clsProduct FindProductByProductName(string productName)
        //{
        //    int ProductID = -1;
        //    int quantity = 0;
        //    decimal Price = 0;
        //    string imageProduct = "";
        //    int catID = -1;

        //    bool isFound = clsProductData.Ge(productName, ref productID, ref quantity, ref price, ref imageProduct, ref catID);
        //    if (isFound)
        //    {
        //        return new clsProduct(productID, productName, quantity, price, imageProduct, catID);
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}


        //public static DataTable GetValidProducts()
        //{
        //    return clsProductData.GetValidProducts(); 
        //}
        public static clsProduct FindProductByID(int ProductID)
        {
            string ProductName = "";
            int quantity = 0;
            decimal price = 0;
            string imageProduct = "";
            int catID = -1;

            bool isFound = clsProductData.GetProductInfoByProductID(ProductID, ref ProductName, ref quantity, ref price, ref imageProduct, ref catID);
            if (isFound)
            {
                return new clsProduct(ProductID, ProductName, quantity, price, imageProduct, catID);
            }
            else
            {
                return null;
            }
        }
        public static int GetProductQuantity(int ProductID)
        {

            return clsProductData.GetProductQuantity(ProductID);
        }

        public static bool DeleteProduct(int ProductID)
        {
            return clsProductData.DeleteProduct(ProductID);
        }

    }

}
