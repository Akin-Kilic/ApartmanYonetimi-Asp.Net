using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using web_tasarim_ve_programlama.DataAccess;

namespace web_tasarim_ve_programlama.ApartmanIslemleri
{
    public partial class DuesOp : System.Web.UI.Page
    {
        int apartmanId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["yonetici"]) == true)
            {
                try
                {
                    DB.Connection();
                    int yoneticiId = Convert.ToInt32(Session["yoneticiid"]);

                    OleDbCommand komut = new OleDbCommand($"select * from users where id = {yoneticiId}", DB.connection);
                    OleDbDataReader reader = komut.ExecuteReader();

                    if (reader.Read())
                    {
                        apartmanId = Convert.ToInt32(reader["apartman_id"]);
                    }

                    OleDbCommand komut2 = new OleDbCommand($"select * from apartments where id = {apartmanId}", DB.connection);
                    OleDbDataReader reader1 = komut2.ExecuteReader();
                    if (reader1.Read())
                    {
                        string a = reader1["dues"].ToString();
                        lblAidatTutari.Text = reader1["dues"].ToString();
                    }
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

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                DB.Connection();
                int yoneticiId = Convert.ToInt32(Session["yoneticiid"]);

                OleDbCommand komut = new OleDbCommand($"select * from users where id = {yoneticiId}", DB.connection);
                OleDbDataReader reader = komut.ExecuteReader();

                if (reader.Read())
                {
                    apartmanId = Convert.ToInt32(reader["apartman_id"]);
                }
                OleDbCommand komut2 = new OleDbCommand($"update apartments set dues={Convert.ToInt32(txtBoxAidat.Text)} where id={apartmanId}", DB.connection);
                komut2.ExecuteNonQuery();
                reader.Close();
                lblAidatTutari.Text = txtBoxAidat.Text;
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
    }
}