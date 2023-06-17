using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using web_tasarim_ve_programlama.DataAccess;
using web_tasarim_ve_programlama.sha;

namespace web_tasarim_ve_programlama
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string shaPass = Sha256Converter.ComputeSha256Hash(tboxSifre.Text);

                DB.Connection();
                OleDbCommand komut = new OleDbCommand($"select * from users where email='{tboxEmail.Text}' and sifre='{shaPass}' ", DB.connection);
                komut.ExecuteNonQuery();
                OleDbDataReader reader = komut.ExecuteReader();

                if (reader.Read())
                {
                    Session.Timeout = 5;
                    if (reader["tip"].ToString() == "0")
                    {
                        //admin
                        Session["admin"] = true;
                        Response.Redirect("AdminAnasayfa.aspx");
                    }
                    else if (reader["tip"].ToString() == "1")
                    {
                        //yönetici
                        Session["yonetici"] = true;
                        Session["yoneticiid"] = reader["id"].ToString();
                        Session["yoneticiapartmanid"] = reader["apartman_id"].ToString();
                        Response.Redirect("YoneticiAnasayfa.aspx");
                    }
                    else if (reader["tip"].ToString() == "2")
                    {
                        //ev sahibi
                        Session["evsahibi"] = true;
                        Session["evsahibiid"] = reader["id"].ToString();
                        Session["evsahibiapartmanid"] = reader["apartman_id"].ToString();
                        Response.Redirect("HomeownerAnasayfa.aspx");
                    }
                    reader.Close();

                }
                else
                {
                    string script = "showNotification();";
                    ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", script, true);
                }


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {

                DB.Disconnection();
            }

        }

    }
}