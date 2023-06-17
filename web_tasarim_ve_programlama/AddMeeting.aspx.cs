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
    public partial class AddMeeting : System.Web.UI.Page
    {
        int apartmanId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["yonetici"]) == true)
            {
                if (!IsPostBack)
                {
                    ddlSaatTarih();
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void ddlSaatTarih()
        {
            // DropDownList için saat seçeneklerini ekleyin
            for (int hour = 0; hour <= 23; hour++)
            {
                ddlHour.Items.Add(new ListItem(hour.ToString("00"), hour.ToString()));
            }

            // DropDownList için dakika seçeneklerini ekleyin
            for (int minute = 0; minute <= 59; minute++)
            {
                ddlMinute.Items.Add(new ListItem(minute.ToString("00"), minute.ToString()));
            }
            ddlHour.SelectedIndex = 1;
            ddlMinute.SelectedIndex = 1;

        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                int yoneticiId = Convert.ToInt32(Session["yoneticiid"].ToString());
                DB.Connection();
                OleDbCommand komut = new OleDbCommand($"select apartman_id from users where id={yoneticiId}", DB.connection);
                OleDbDataReader reader = komut.ExecuteReader();

                if (reader.Read())
                {
                    apartmanId = Convert.ToInt32(reader[0]);
                    reader.Close();

                    DateTime selectedDate = Calendar1.SelectedDate;
                    string tarih = selectedDate.ToString("dd-MM-yyyy");
                    string saat = ddlHour.SelectedValue.ToString();
                    string dakika = ddlMinute.SelectedValue.ToString();

                    string fulTarih = tarih + " " + saat + ":" + dakika + ":00";

                    OleDbCommand komut2 = new OleDbCommand($"insert into meeting (baslik, konu, tarih, konum, apartman_id) values('{TextBox1.Text.ToString()}', '{TextBox2.Text.ToString()}', '{fulTarih}', '{TextBox3.Text.ToString()}', {apartmanId})", DB.connection);
                    komut2.ExecuteNonQuery();

                    string script = "showAddMeetSuccess();";
                    ScriptManager.RegisterStartupScript(this, GetType(), "showAddMeetSuccess", script, true);

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