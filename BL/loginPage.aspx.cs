using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Data;
using Productim.Classes;
using Productim.DAL;
using System.Web.Script.Serialization;

namespace Productim.BL
{
    public partial class loginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            DBServicesAPP dbs = new DBServicesAPP();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            DataTable UserDetails = new DataTable();


            if (Request.QueryString == null)
            {
                Response.End();
                return;
            }

            NameValueCollection workerDetailQS = Request.QueryString;


            string UserNameString = workerDetailQS["id"];
            string passwordString = workerDetailQS["password"];


            try
            {
                UserDetails = dbs.getPass(UserNameString);

                if (passwordString != UserDetails.Rows[0].ItemArray[0].ToString())
                {
                    Response.StatusCode = 1;   // user name exists BUT password is not correct
                }
                //else
                //{
                //    string a = "f";
                //}


            }


            catch (Exception ex)
            {
                Logger.writeToLog(LoggerLevel.ERROR, "page :loginPage.aspx.cs, the exeption message is : " + ex.Message);
                Response.StatusCode = 3;  // empty pass and user name 
            }

            UserDetails.Columns[1].ColumnName = "id";
            string jsonStringProducts = serializer.Serialize(SerializeTable(UserDetails));
            //string a = "[{UserId:1}]";//[{"UserPassword":"1234","id":1}]
            Response.Write(jsonStringProducts);
            Response.End();
        }

        private IEnumerable<Dictionary<string, object>> SerializeTable(DataTable table)
        {
            return table.DefaultView.OfType<DataRowView>().Select(row =>
            {
                var result = new Dictionary<string, object>();
                foreach (DataColumn column in table.Columns)
                {
                    result.Add(column.ColumnName, row.Row[column.ColumnName]);
                }

                return result;
            });
        }
    }
}