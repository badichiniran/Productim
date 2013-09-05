using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Productim.BL
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string a = "1,2,P3";
            string input = "1,2,3";
            int index = input.IndexOf(",P");
            if (index > 0)
                input = input.Substring(0, index);

            string d = input;

        }
    }
}