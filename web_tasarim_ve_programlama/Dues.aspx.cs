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
    public partial class Dues : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["evsahibi"]) == true)
            {
                try
                {
                    int id = Convert.ToInt32(Session["evsahibiid"]);

                    DB.Connection();
                    OleDbCommand komut = new OleDbCommand($"select apartman_id from users where id={id}", DB.connection);
                    OleDbDataReader reader = komut.ExecuteReader();
                    if (reader.Read())
                    {
                        int apartmanId = Convert.ToInt32(reader[0].ToString());

                        OleDbCommand komut2 = new OleDbCommand($"select * from apartments where id = {apartmanId}", DB.connection);
                        OleDbDataReader reader2 = komut2.ExecuteReader();
                        if (reader2.Read())
                        {
                            string dues = reader2["dues"].ToString();
                            string apartmanAdi = reader2["apartman_adi"].ToString();
                            aidat.Text = apartmanAdi + " adidat tutarı: " + dues +" TL";
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                finally { DB.Disconnection(); }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

    }
}