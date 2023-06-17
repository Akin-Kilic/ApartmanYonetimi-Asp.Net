using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;


namespace web_tasarim_ve_programlama.DataAccess
{
    public partial class DB
    {
        public static OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\akin6\\Desktop\\web_proje.accdb");

        public static void Connection()
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

        }
        public static void Disconnection()
        {
            connection.Close();

        }

    }
}