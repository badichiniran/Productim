using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Productim.DAL;
using System.Collections.Specialized;
using System.Web.Script.Serialization;
using Productim.Classes;

namespace Productim.BL
{
    public partial class FinishShopping : System.Web.UI.Page
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

           

           


            try
            {
                string UserName = requestQuery["UserName"];
                dbs.FinishShopping(UserName);

            }

            catch (Exception ex)
            {
                Logger.writeToLog(LoggerLevel.ERROR, "page :ActivityShow.aspx.cs, the exeption message is : " + ex.Message);
                
            }
           

          
            Response.End();

        }


   
    }
}