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
            return "SELECT UserPassword,UserId FROM dbo.Users WHERE UserName = '" + UserName + "'";
        }



        public static String ProductCategories()
        {
            return "SELECT * FROM .dbo.Product_categories";
        }

        public static String getProducts()
        {
            return "SELECT Product_id,Product_desc FROM Products";
        }

        public static String insertProductToList(Product p)
        {
            String command;
            string getUserList = "DECLARE @tmpList_id int SET @tmpList_id = (select List_id from List where UserId='"+p.UserId+"' and  Is_Active=1 )";
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Values({0}, '{1}', '{2}' , '{3}' , '{4}'  )","@tmpList_id",p.Product_id, p.Product_amount,p.Units,p.Comment);
            String prefix = "INSERT INTO Product_list " + "( List_id, Product_id,Product_amount,Unit_id,Comment) ";

            command = getUserList+ prefix + sb.ToString();

            return command;
        }

        public static String insertNewProductToList(Product p)
        {
            String command;

            string insertNewPdoduct=" INSERT INTO Products (Product_desc,Product_category_id,IsApproved,UserId) VALUES ('"+p.Product_desc+"',10,1,"+p.UserId+")";
            string getNewPdoductId = " DECLARE @tmpProduct_id int SET @tmpProduct_id = (select top 1 Product_id from Products order by time_stmp desc) ";
            string getUserList = " DECLARE @tmpList_id int SET @tmpList_id = (select List_id from List where UserId='" + p.UserId + "' and  Is_Active=1 ) ";
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Values({0}, {1}, '{2}' , '{3}' , '{4}'  )", "@tmpList_id", "@tmpProduct_id", p.Product_amount, p.Units, p.Comment);
            String prefix = "INSERT INTO Product_list " + "( List_id, Product_id,Product_amount,Unit_id,Comment) ";

            command = insertNewPdoduct+getNewPdoductId+ getUserList + prefix + sb.ToString();

            return command;
        }
        public static String ShowShoppingList()
        {
            string showProducts = "SELECT     dbo.products.product_id,dbo.ProductTypes.ProductType_desc, dbo.products.product_name, dbo.products.product_amount FROM         dbo.products INNER JOIN  dbo.ProductTypes ON dbo.products.ProductType_id = dbo.ProductTypes.ProductType_id WHERE products.isPurchesd=0 ORDER BY dbo.ProductTypes.ProductType_desc";
            return showProducts;
        }

        public static String ShowShoppingList_byUserName(string UserId)
        {

            return "SELECT Product_list_id,Product_desc,Product_category_desc,Unit_desc,Comment,Is_purchased,Product_amount FROM View_ShowProductList  where UserId='" + UserId + "'";
        }

        public static String RemoveProduct(string Product_list_id)
        {
            string removeProduct = "UPDATE [Product_list] SET [Is_purchased] = 1 WHERE Product_list_id in (" + Product_list_id + ")";
            return removeProduct;
        }


        public static String DeleteProduct(string Product_list_id)
        {
            string deleteProduct = "DELETE FROM Product_list WHERE Product_list_id in (" + Product_list_id + ")";
            return deleteProduct;
        }
        public static String FinishShopping(string UserId)
        {
            String command;
            string getOldList = " DECLARE @OldList_id int SET @OldList_id = (select List_id from List where UserId='" + UserId + "' and  Is_Active=1 )";
            string updateList = " UPDATE [List] SET [Is_Active] = 0 WHERE UserName='" + UserId + "' and Is_Active=1 ";
            string insertNewList = " INSERT INTO [List] (UserName) VALUES('" + UserId + "') ";
            string getNewListId = " DECLARE @NewList_id int SET @NewList_id = (select List_id from List where UserName='" + UserId + "' and  Is_Active=1 )";
            string updateProductListId = " UPDATE [Product_list] SET [List_id] = @NewList_id WHERE List_id=@OldList_id  and Is_purchased=0 ";
            command = getOldList + updateList + insertNewList + getNewListId + updateProductListId;

            return command;
        }

    }
}