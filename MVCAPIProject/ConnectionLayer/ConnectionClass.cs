using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace MVCAPIProject.ConnectionLayer
{
    public class ConnectionClass
    {

        string ConnectTo;
        SqlConnection con = null;
        public ConnectionClass()
        {
            ConnectTo = ConfigurationManager.ConnectionStrings["NewPlanetToolConnectionString"].ConnectionString;

        }
        public SqlConnection OpenConn()
        {
            con = new SqlConnection(ConnectTo);
            con.Open();
            return con;

        }
        public void CloseConn()
        {
            con.Close();

        }
    }
}