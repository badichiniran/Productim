using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Productim.DAL;

namespace Productim
{
    public class Product
    {
        public Product()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        DBServicesAPP dbs = new DBServicesAPP();


        string product_id;
        public string Product_id
        {
            get { return product_id; }
            set { product_id = value; }
        }
        string units;
        public string Units
        {
            get { return units; }
            set { units = value; }
        }

        string product_amount;
        public string Product_amount
        {
            get { return product_amount; }
            set { product_amount = value; }
        }

        string comment;
        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }

        string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

     


        public void RemoveProduct()
        {
            try
            {
                dbs.RemoveProduct(this);
            }
            catch
            {
                throw;
            }

        }
    }
}