﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Productim.Classes;
using System.Collections.Specialized;
using Productim.DAL;

namespace Productim.BL
{
    public partial class InsertProduct : System.Web.UI.Page
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
                Product product = new Product()
                {

                    Prodect_name = requestQuery["Prodect_name"],
                    Prodect_amount = requestQuery["Prodect_amount"],
                    ProductType_id = requestQuery["ProductType_id"],
                };
                product.insertProduct();


            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("AnimelType_id_FK1"))
                    Response.StatusCode = 1; // must choose AnimelType
                else
                {
                    Response.StatusCode = 999;  //general error
                    Logger.writeToLog(LoggerLevel.ERROR, "page :InjuredPet_Incident.aspx.cs, the exeption message is : " + ex.Message);
                    //send mail to systemsupport 
                }
            }

        }
    }
}