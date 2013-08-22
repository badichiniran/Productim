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


        string prodect_id;
        public string Prodect_id
        {
            get { return prodect_id; }
            set { prodect_id = value; }
        }
        string prodect_name;
        public string Prodect_name
        {
            get { return prodect_name; }
            set { prodect_name = value; }
        }

        string prodect_amount;
        public string Prodect_amount
        {
            get { return prodect_amount; }
            set { prodect_amount = value; }
        }

        string productType_id;
        public string ProductType_id
        {
            get { return productType_id; }
            set { productType_id = value; }
        }

        public void insertProduct()
        {
            try
            {
                dbs.insertProduct(this);
            }
            catch
            {
                throw;
            }

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