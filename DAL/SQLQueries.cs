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


        public static String insertProduct(Product p)
        {
            string insertProduct = " INSERT INTO Prodects (Prodect_name,Prodect_amount,ProductType_id) VALUES ('" + p.Prodect_name + "','" + p.Prodect_amount + "','" + p.ProductType_id + "')";
            return insertProduct;
        }

        public static String ShowShoppingList()
        {
            string showProducts = "SELECT     dbo.Prodects.Prodect_id,dbo.ProductTypes.ProductType_desc, dbo.Prodects.Prodect_name, dbo.Prodects.Prodect_amount FROM         dbo.Prodects INNER JOIN  dbo.ProductTypes ON dbo.Prodects.ProductType_id = dbo.ProductTypes.ProductType_id WHERE Prodects.isPurchesd=0 ORDER BY dbo.ProductTypes.ProductType_desc";
            return showProducts;
        }

        public static String ShowShoppingList_byType(string productType)
        {
            string showProducts = "  SELECT dbo.Prodects.Prodect_id,dbo.ProductTypes.ProductType_desc, dbo.Prodects.Prodect_name, dbo.Prodects.Prodect_amount FROM dbo.Prodects INNER JOIN  dbo.ProductTypes ON dbo.Prodects.ProductType_id = dbo.ProductTypes.ProductType_id WHERE Prodects.isPurchesd=0 and dbo.ProductTypes.ProductType_id=" + productType + " ORDER BY dbo.Prodects.Prodect_name desc";
            return showProducts;
        }

        public static String RemoveProduct(Product p)
        {
            string removeProduct = "Update Prodects SET isPurchesd =1 WHERE Prodect_id ='" + p.Prodect_id + "'";
            return removeProduct;
        }



    }
}