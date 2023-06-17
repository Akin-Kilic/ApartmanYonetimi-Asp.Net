using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using web_tasarim_ve_programlama.DataAccess;

namespace web_tasarim_ve_programlama.Homeowner
{
    public partial class Meeting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["evsahibi"]) == true)
            {
                try
                {
                    int apartmanId = Convert.ToInt32(Session["evsahibiapartmanid"]);
                    DB.Connection();
                    OleDbCommand komut = new OleDbCommand($"select * from meeting where apartman_id={apartmanId}", DB.connection);
                    OleDbDataReader reader = komut.ExecuteReader();
                    DataList1.DataSource = reader;
                    DataList1.DataBind();
                    reader.Close();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    DB.Disconnection();
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}