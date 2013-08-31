﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using Productim.Classes;

namespace Productim.DAL
{
    public class DBServicesAPP
    {
        public SqlDataAdapter da;
        public DataTable dt;
        public string connectionString;
        public DBServicesAPP()
        {
            connectionString = WebConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        }

        public SqlConnection connect()
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                return con;
            }
            catch (Exception ex)
            {
                Logger.writeToLog(LoggerLevel.ERROR, "page :DBServicesAPP.cs, function: connect(), exeption message: " + ex.Message);
                throw;
            }
        }

        public void disconnect(SqlConnection con)
        {
            if (con != null)
            {
                try
                {
                    con.Close();
                }
                catch (Exception ex)
                {
                    Logger.writeToLog(LoggerLevel.ERROR, "page :DBServicesAPP.cs, function: disconnect(), exeption message: " + ex.Message);
                    throw;
                }
            }
        }

        public DataTable getPass(string UserName)
        {
            SqlConnection con;
            try
            {
                con = connect(); // open the connection to the database/
                da = new SqlDataAdapter(SQLQueries.getPass(UserName), con); // create the data adapter
                DataSet ds = new DataSet(); 
                da.Fill(ds);       // Fill the datatable (in the dataset), using the Select command 
                dt = ds.Tables[0];     // point to the cars table , which is the only table in this case

            }
            catch (Exception ex)
            {
                Logger.writeToLog(LoggerLevel.ERROR, "page :DBServicesAPP.cs, function: getVolonteerPass(), exeption message: " + ex.Message);
                throw ex;
            }
            disconnect(con);
            return dt;
        }

        public DataTable getProductTypes()
        {
            SqlConnection con;

            try
            {
                con = connect();
                da = new SqlDataAdapter(SQLQueries.ProductTypes(), con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0];

            }
            catch (Exception ex)
            {
                Logger.writeToLog(LoggerLevel.ERROR, "page :DBServicesAPP.cs, function: getAnimalTypes(), exeption message: " + ex.Message);
                throw ex;
            }
            disconnect(con);
            return dt;

        }

        public DataTable getProducts()
        {
            SqlConnection con;

            try
            {
                con = connect();
                da = new SqlDataAdapter(SQLQueries.getProducts(), con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0];

            }
            catch (Exception ex)
            {
                Logger.writeToLog(LoggerLevel.ERROR, "page :DBServicesAPP.cs, function: getAnimalTypes(), exeption message: " + ex.Message);
                throw ex;
            }
            disconnect(con);
            return dt;

        }

        public void insertProductToList(Product p)
        {
            SqlConnection con;

            try
            {
                con = connect();
                da = new SqlDataAdapter(SQLQueries.insertProductToList(p), con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables["Products"];

            }
            catch (Exception ex)
            {
               
                throw ex;
            }
            disconnect(con);
            

        }

        public DataTable ShowShoppingList()
        {

            SqlConnection con;
            try
            {
                con = connect();
                da = new SqlDataAdapter(SQLQueries.ShowShoppingList(), con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0];

            }
            catch (Exception ex)
            {
                Logger.writeToLog(LoggerLevel.ERROR, "page :DBServicesAPP.cs, function: ShowShoppingList(), exeption message: " + ex.Message);
                throw ex;
            }
            disconnect(con);
            return dt;
        }

        public DataTable ShowShoppingList_byUserName(string UserName)
        {

            SqlConnection con;
            try
            {
                con = connect();
                da = new SqlDataAdapter(SQLQueries.ShowShoppingList_byUserName(UserName), con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0];

            }
            catch (Exception ex)
            {
                Logger.writeToLog(LoggerLevel.ERROR, "page :DBServicesAPP.cs, function: getVeg_ShoppingList(), exeption message: " + ex.Message);
                throw ex;
            }
            disconnect(con);
            return dt;
        }
        public void RemoveProduct(string Product_list_id)
        {

            SqlConnection con;
            try
            {
                con = connect();
                da = new SqlDataAdapter(SQLQueries.RemoveProduct(Product_list_id), con);
                DataSet ds = new DataSet();
                da.Fill(ds);

            }
            catch (Exception ex)
            {
              
                throw ex;
            }
            disconnect(con);
        }


        public void DeleteProduct(string Product_list_id)
        {

            SqlConnection con;
            try
            {
                con = connect();
                da = new SqlDataAdapter(SQLQueries.DeleteProduct(Product_list_id), con);
                DataSet ds = new DataSet();
                da.Fill(ds);

            }
            catch (Exception ex)
            {
              
                throw ex;
            }
            disconnect(con);
        }
        public void FinishShopping(string UserName)
        {

            SqlConnection con;
            try
            {
                con = connect();
                da = new SqlDataAdapter(SQLQueries.FinishShopping(UserName), con);
                DataSet ds = new DataSet();
                da.Fill(ds);

            }
            catch (Exception ex)
            {
              
                throw ex;
            }
            disconnect(con);
        }
    }
}