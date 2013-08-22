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
        string product_name;
        public string Product_name
        {
            get { return product_name; }
            set { product_name = value; }
        }

        string product_amount;
        public string Product_amount
        {
            get { return product_amount; }
            set { product_amount = value; }
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