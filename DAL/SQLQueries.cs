using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;


namespace Productim.DAL
{
    public class SQLQueries
    {
        public SQLQueries()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static String getPass(string UserName)
        {
            return "SELECT UserPassword FROM dbo.Users WHERE UserName = '" + UserName + "'";
        }



        public static String ProductTypes()
        {
            return "SELECT * FROM .dbo.ProductTypes";
        }

        public static String getProducts()
        {
            return "SELECT Product_id,Product_desc FROM Products";
        }

        public static String insertProduct(Product p)
        {
            string insertProduct = " INSERT INTO products (product_name,product_amount,ProductType_id) VALUES ('" + p.Product_name + "','" + p.Product_amount + "','" + p.ProductType_id + "')";
            return insertProduct;
        }

        public static String ShowShoppingList()
        {
            string showProducts = "SELECT     dbo.products.product_id,dbo.ProductTypes.ProductType_desc, dbo.products.product_name, dbo.products.product_amount FROM         dbo.products INNER JOIN  dbo.ProductTypes ON dbo.products.ProductType_id = dbo.ProductTypes.ProductType_id WHERE products.isPurchesd=0 ORDER BY dbo.ProductTypes.ProductType_desc";
            return showProducts;
        }

        public static String ShowShoppingList_byType(string productType)
        {
            string showProducts = "  SELECT dbo.products.product_id,dbo.ProductTypes.ProductType_desc, dbo.products.product_name, dbo.products.product_amount FROM dbo.products INNER JOIN  dbo.ProductTypes ON dbo.products.ProductType_id = dbo.ProductTypes.ProductType_id WHERE products.isPurchesd=0 and dbo.ProductTypes.ProductType_id=" + productType + " ORDER BY dbo.products.product_name desc";
            return showProducts;
        }

        public static String RemoveProduct(Product p)
        {
            string removeProduct = "Update products SET isPurchesd =1 WHERE product_id ='" + p.Product_id + "'";
            return removeProduct;
        }



    }
}