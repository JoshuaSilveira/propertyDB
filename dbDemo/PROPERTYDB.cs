﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace dbDemo
{
    public class PROPERTYDB
    {
        private static string User { get { return "root"; } }
        private static string Password { get { return "root"; } }
        private static string Database { get { return "propertydb"; } }
        private static string Server { get { return "localhost"; } }
        private static string Port { get { return "3306"; } }

       
        private static string ConnectionString
        {
            get
            {
                return "server = " + Server
                    + "; user = " + User
                    + "; database = " + Database
                    + "; port = " + Port
                    + "; password = " + Password;
            }
        }
        public List<Dictionary<String, String>> List_Query(string query)
        {
            MySqlConnection Connect = new MySqlConnection(ConnectionString);

            // INPUT -> (string) SELECT QUERY 
            // e.g. "select * from students";
            // OUTPUT -> (List<Dictionary<String,String>>) RESULT SET 
            // e.g. 
            //[
            //  {"STUDENTFNAME":"SARAH","STUDENTLNAME":"Valdez","STUDENTNUMBER":"N1678","ENROLMENTDATE":"2018-06-18"},
            //  {"STUDENTFNAME":"Jennifer","STUDENTLNAME":"FAULKNER","STUDENTNUMBER":"N1679","ENROLMENTDATE":"2018-08-02"},
            //  {"STUDENTFNAME":"Austin","STUDENTLNAME":"Simon","STUDENTNUMBER":"N1682","ENROLMENTDATE":"2018-06-14"},
            //  ...
            //] 
            List<Dictionary<String, String>> ResultSet = new List<Dictionary<String, String>>();

            // try{} catch{} will attempt to do everything inside try{}
            // if an error happens inside try{}, then catch{} will execute instead.
            // very useful for debugging without the whole program crashing!
            // this can be easily abused and should be used sparingly.
            try
            {
                Debug.WriteLine("Connection Initialized...");

                //open the db connection
                Connect.Open();
                //give the connection a query
                MySqlCommand cmd = new MySqlCommand(query, Connect);
                //grab the result set
                MySqlDataReader resultset = cmd.ExecuteReader();


                //for every row in the result set
                while (resultset.Read())
                {
                    Dictionary<String, String> Row = new Dictionary<String, String>();
                    //for every column in the row
                    for (int i = 0; i < resultset.FieldCount; i++)
                    {
                        Row.Add(resultset.GetName(i), resultset.GetString(i));
                    }
                    ResultSet.Add(Row);
                }//end row
                resultset.Close();


            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong!");
                Debug.WriteLine(ex.ToString());

            }

            Connect.Close();
            Debug.WriteLine("Database Connection Terminated.");

            return ResultSet;
        }
    }
}