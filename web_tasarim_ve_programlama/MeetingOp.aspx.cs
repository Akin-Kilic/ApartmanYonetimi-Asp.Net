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
    public partial class MeetingOp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["yonetici"]) == true)
            {
                if (!IsPostBack)
                {
                    DataList1.ItemDataBound += DataList1_ItemDataBound;


                    try
                    {
                        int apartmanId = Convert.ToInt32(Session["yoneticiapartmanid"].ToString());
                        DB.Connection();
                        OleDbCommand komut = new OleDbCommand($"select * from meeting where apartman_id = {apartmanId}", DB.connection);
                        OleDbDataReader reader = komut.ExecuteReader();
                        DataList1.DataSource = reader;
                        DataList1.DataBind();

                        string a = Request.Form["ddlHour"];
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

            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DropDownList ddlHour = (DropDownList)e.Item.FindControl("ddlHour");
                DropDownList ddlMinute = (DropDownList)e.Item.FindControl("ddlMinute");

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
        }


        protected void btnKaydet_Click(object sender, EventArgs e)
        {

            try
            {
                Button buton = (Button)sender;
                DataListItem item = (DataListItem)buton.NamingContainer;
                Label labelID = (Label)item.FindControl("lblId");
                int id = Convert.ToInt32(labelID.Text);
                TextBox txtboxBaslik = (TextBox)item.FindControl("TextBox1");
                string baslik = Convert.ToString(txtboxBaslik.Text);
                TextBox txtboxKonu = (TextBox)item.FindControl("TextBox2");
                string konu = Convert.ToString(txtboxKonu.Text);
                Calendar calader = (Calendar)item.FindControl("Calendar1");
                DateTime selectedDate = ((Calendar)calader.FindControl("Calendar1")).SelectedDate;
                string tarih = selectedDate.ToString("dd/MM/yyyy");
                TextBox txtboxKonum = (TextBox)item.FindControl("TextBox3");
                string konum = Convert.ToString(txtboxKonum.Text);
                DropDownList ddlSaat = (DropDownList)item.FindControl("ddlHour");
                string saat = saat = Convert.ToString(ddlSaat.Text);
                DropDownList ddlDakika = (DropDownList)item.FindControl("ddlMinute");
                string dakika = dakika = Convert.ToString(ddlDakika.Text);

                string fulTarih = "";


                DB.Connection();


                fulTarih = tarih + " " + saat + ":" + dakika + ":00";
                OleDbCommand komut = new OleDbCommand($"update meeting set baslik='{baslik}', konu='{konu}', tarih='{fulTarih}', konum='{konum}' where id = {id}", DB.connection);
                komut.ExecuteNonQuery();



            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                DB.Disconnection();
            }
            try
            {
                DataList1.ItemDataBound += DataList1_ItemDataBound;
                int apartmanId = Convert.ToInt32(Session["yoneticiapartmanid"].ToString());
                DB.Connection();
                OleDbCommand komut = new OleDbCommand($"select * from meeting where apartman_id = {apartmanId}", DB.connection);
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

        protected void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                Button buton = (Button)sender;
                DataListItem item = (DataListItem)buton.NamingContainer;
                Label labelID = (Label)item.FindControl("lblId");
                int id = Convert.ToInt32(labelID.Text);
                DB.Connection();
                OleDbCommand komut = new OleDbCommand($"delete from meeting where id = {id}", DB.connection);
                komut.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                DB.Disconnection();
            }
            try
            {
                DataList1.ItemDataBound += DataList1_ItemDataBound;
                int apartmanId = Convert.ToInt32(Session["yoneticiapartmanid"].ToString());
                DB.Connection();
                OleDbCommand komut = new OleDbCommand($"select * from meeting where apartman_id = {apartmanId}", DB.connection);
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
    }
}