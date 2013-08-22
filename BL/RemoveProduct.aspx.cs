using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Productim.DAL;
using System.Collections.Specialized;
using Productim.Classes;

namespace Productim.BL
{
    public partial class RemoveProduct : System.Web.UI.Page
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

                Product p = new Product()
                {
                    Prodect_id = requestQuery["Prodect_id"],


                };

                p.RemoveProduct();

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Violation of UNIQUE KEY constraint"))
                    Response.StatusCode = 999;
                else
                {
                    Response.StatusCode = 1;  //general error
                    Logger.writeToLog(LoggerLevel.ERROR, "page :ActivityRequestDogTour.aspx.cs, Faild to insertRequest. the exeption message is : " + ex.Message);
                    //send mail to systemsupport + log
                }
            }

        }
    }
}