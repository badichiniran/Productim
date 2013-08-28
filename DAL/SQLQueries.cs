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

        public static String insertProductToList(Product p)
        {
            String command;
            string getUserList = "DECLARE @tmpList_id int SET @tmpList_id = (select List_id from List where UserName='"+p.UserName+"' and  Is_Active=1 )";
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Values({0}, '{1}', '{2}' , '{3}' , '{4}'  )","@tmpList_id",p.Product_id, p.Product_amount,p.Units,p.Comment);
            String prefix = "INSERT INTO Product_list " + "( List_id, Product_id,Product_amount,Unit_id,Comment) ";

            command = getUserList+ prefix + sb.ToString();

            return command;
        }

        public static String ShowShoppingList()
        {
            string showProducts = "SELECT     dbo.products.product_id,dbo.ProductTypes.ProductType_desc, dbo.products.product_name, dbo.products.product_amount FROM         dbo.products INNER JOIN  dbo.ProductTypes ON dbo.products.ProductType_id = dbo.ProductTypes.ProductType_id WHERE products.isPurchesd=0 ORDER BY dbo.ProductTypes.ProductType_desc";
            return showProducts;
        }

        public static String ShowShoppingList_byUserName(string UserName)
        {

            return "SELECT Product_list_id,Product_desc,Product_category_desc,Unit_desc,Comment,Is_purchased,Product_amount FROM View_ShowProductList  where UserName='" + UserName + "'";
        }

        public static String RemoveProduct(string Product_list_id)
        {
            string removeProduct = "UPDATE [Product_list] SET [Is_purchased] = 1 WHERE Product_list_id in (" + Product_list_id + ")";
            return removeProduct;
        }



    }
}