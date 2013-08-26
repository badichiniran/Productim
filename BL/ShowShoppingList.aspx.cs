using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Productim.Classes;
using System.Web.Script.Serialization;
using System.Collections.Specialized;
using Productim.DAL;

namespace Productim.BL
{
    public partial class ShowShoppingList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DBServicesAPP dbs = new DBServicesAPP();
            if (Request.QueryString == null)
            {
                Response.End();
                return;
            }
            NameValueCollection requestQuery = Request.QueryString;

            JavaScriptSerializer serializer = new JavaScriptSerializer();

            DataTable ShoppingList;


            try
            {
                string UserName = requestQuery["UserName"];
                ShoppingList = dbs.ShowShoppingList_byUserName(UserName);

            }

            catch (Exception ex)
            {
                Logger.writeToLog(LoggerLevel.ERROR, "page :ActivityShow.aspx.cs, the exeption message is : " + ex.Message);
                throw;
            }
            string jsonStringShoppingList = serializer.Serialize(SerializeTable(ShoppingList));
           
            Response.Write(jsonStringShoppingList);
            Response.End();

        }


        private IEnumerable<Dictionary<string, object>> SerializeTable(DataTable table)
        {
            return table.DefaultView.OfType<DataRowView>().Select(row =>
            {
                var result = new Dictionary<string, object>();
                foreach (DataColumn column in table.Columns)
                {
                    result.Add(column.ColumnName, Convert.ToString(row.Row[column.ColumnName]));
                }

                return result;
            });
        }
    }
}