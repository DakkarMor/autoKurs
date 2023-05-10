using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace kursovik.DAO
{
    public class DAO
    {
        private const string Conn = "Data Source=(localdb)\\MSSqlLocalDB;Initial Catalog=bd1;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
        public SqlConnection Connection { get; set; }
        public void Connect()
        {
            Connection = new SqlConnection(Conn);
            Connection.Open();
        }
        public void Disconnect()
        {
            Connection.Close();
        }
    }
}