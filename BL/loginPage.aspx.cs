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

namespace Productim.BL
{
    public partial class loginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DBServicesAPP dbs = new DBServicesAPP();

            if (Request.QueryString == null)
            {
                Response.End();
                return;
            }

            NameValueCollection workerDetailQS = Request.QueryString;


            string UserIdString = workerDetailQS["id"];
            string passwordString = workerDetailQS["password"];

            DataTable UserDetails;
            try
            {
                UserDetails = dbs.getPass(UserIdString);

                if (passwordString != UserDetails.Rows[0].ItemArray[0].ToString())
                {
                    Response.StatusCode = 1;   // user name exists BUT password is not correct
                }

            }


            catch (Exception ex)
            {
                Logger.writeToLog(LoggerLevel.ERROR, "page :loginPage.aspx.cs, the exeption message is : " + ex.Message);
                Response.StatusCode = 3;  // empty pass and user name 
            }

            Response.End();
        }
    }
}