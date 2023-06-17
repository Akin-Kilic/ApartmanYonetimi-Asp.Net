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
    public partial class FlatOp : System.Web.UI.Page
    {
        int apartmanId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["yonetici"]) == true)
            {
                
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            try
            {
                DB.Connection();
                int daireSayisi = Convert.ToInt32(txtDaireSayisi.Text);

                int yoneticiId = Convert.ToInt32(Session["yoneticiid"]);

                string input = txtDaireSayisi.Text;
                int number;
                bool isNumber = int.TryParse(input, out number);

                if (isNumber)
                {
                    OleDbCommand komut = new OleDbCommand($"select * from users where id = {yoneticiId}", DB.connection);
                    OleDbDataReader reader = komut.ExecuteReader();

                    if (reader.Read())
                    {
                        apartmanId = Convert.ToInt32(reader["apartman_id"]);
                    }
                    OleDbCommand komut4 =new OleDbCommand($"update apartments set daire_sayisi = {daireSayisi} where id={apartmanId}",DB.connection);
                    komut4.ExecuteNonQuery();

                    OleDbCommand komut3 = new OleDbCommand($"select * from flats where apartman_id = {apartmanId}", DB.connection);
                    OleDbDataReader reader2 = komut3.ExecuteReader();
                    if (reader2.Read())
                    {
                        string script = "showFlatErrorNotification();";
                        ScriptManager.RegisterStartupScript(this, GetType(), "showFlatErrorNotification", script, true);
                    }
                    else
                    {
                        for (int i = 1; i <= daireSayisi; i++)
                        {
                            OleDbCommand komut2 = new OleDbCommand($"insert into flats (apartman_id, daire_no, bosMu) values ({apartmanId}, {i}, {false})", DB.connection);
                            komut2.ExecuteNonQuery();
                        }
                        string script = "showFlatNotification();";
                        ScriptManager.RegisterStartupScript(this, GetType(), "showFlatNotification", script, true);
                    }

                    reader2.Close();
                    reader.Close();
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