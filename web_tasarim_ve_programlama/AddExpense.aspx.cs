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
    public partial class AddExpense : System.Web.UI.Page
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

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                int yoneticiId = Convert.ToInt32(Session["yoneticiid"]);
                DB.Connection();
                OleDbCommand komut = new OleDbCommand($"select apartman_id from users where id={yoneticiId}", DB.connection);
                OleDbDataReader reader = komut.ExecuteReader();

                decimal para = Convert.ToDecimal(txtMiktar.Text);

                if (reader.Read())
                {
                    apartmanId = Convert.ToInt32(reader[0]);
                    reader.Close();
                    OleDbCommand komut2 = new OleDbCommand($"insert into expenses (apartman_id, baslik, miktar) values ({apartmanId}, '{txtBaslik.Text}', {para} )", DB.connection);
                    komut2.ExecuteNonQuery();
                }
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