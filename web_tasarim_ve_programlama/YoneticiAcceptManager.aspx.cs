using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using web_tasarim_ve_programlama.DataAccess;

namespace web_tasarim_ve_programlama
{
    public partial class YoneticiAcceptManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["yonetici"]) == true)
            {
                if (IsPostBack)
                {
                    try
                    {
                        DB.Connection();
                        OleDbCommand komut = new OleDbCommand("select * from evsahibibasvuru", DB.connection);
                        OleDbDataReader reader = komut.ExecuteReader();
                        DataList1.DataSource = reader;
                        DataList1.DataBind();
                        reader.Close();

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
                else
                {
                    try
                    {
                        DB.Disconnection();
                        DB.Connection();
                        OleDbCommand komut = new OleDbCommand("select * from evsahibibasvuru", DB.connection);
                        OleDbDataReader reader = komut.ExecuteReader();
                        DataList1.DataSource = reader;
                        DataList1.DataBind();
                        reader.Close();
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
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnOnayla_Click(object sender, EventArgs e)
        {
            //string email;
            try
            {
                Button buton = (Button)sender;
                DataListItem item = (DataListItem)buton.NamingContainer;
                Label labelID = (Label)item.FindControl("lblId");
                int id = Convert.ToInt32(labelID.Text);
                Label lblAd = (Label)item.FindControl("lblIsim");
                string ad = Convert.ToString(lblAd.Text);
                Label lblSoyad = (Label)item.FindControl("lblSoyisim");
                string soyad = Convert.ToString(lblSoyad.Text);
                Label lblKullaniciAdi = (Label)item.FindControl("lblKullaniciAdi");
                string kullaniciAdi = Convert.ToString(lblKullaniciAdi.Text);
                Label lblSifre = (Label)item.FindControl("lblSifre");
                string sifre = Convert.ToString(lblSifre.Text);
                Label lblEmail = (Label)item.FindControl("lblEmail");
                string email = Convert.ToString(lblEmail.Text);
                Label lblApartmanId = (Label)item.FindControl("lblApartmanId");
                int apartmanId = Convert.ToInt32(lblApartmanId.Text);
                Label lblDaireNo = (Label)item.FindControl("lblDaireNo");
                int daireNo = Convert.ToInt32(lblDaireNo.Text);
                Label lblTelNo = (Label)item.FindControl("lblTelNo");
                string telNo = Convert.ToString(lblTelNo.Text);


                DB.Connection();
                
                OleDbCommand komut3 = new OleDbCommand($"insert into users (isim, soyisim, kullanici_adi, email, sifre, telno, tip, apartman_id, flat) values ('{ad}', '{soyad}', '{kullaniciAdi}', '{email}', '{sifre}', '{telNo}', {2}, {apartmanId}, {daireNo})", DB.connection);
                komut3.ExecuteNonQuery();

                OleDbCommand komut = new OleDbCommand($"delete from evsahibibasvuru where id = {id}", DB.connection);
                komut.ExecuteNonQuery();

                OleDbCommand komut2 = new OleDbCommand("select * from evsahibibasvuru", DB.connection);
                OleDbDataReader reader = komut2.ExecuteReader();
                DataList1.DataSource = reader;
                DataList1.DataBind();
                reader.Close();


                OleDbCommand komut4 = new OleDbCommand($"update flats set bosMu = {true} where apartman_id = {apartmanId} and daire_no = {daireNo}",DB.connection);
                komut4.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally { DB.Disconnection(); }

        }

        protected void btnReddet_Click(object sender, EventArgs e)
        {
            try
            {
                Button buton = (Button)sender;
                DataListItem item = (DataListItem)buton.NamingContainer;
                Label labelID = (Label)item.FindControl("lblID");
                int id = Convert.ToInt32(labelID.Text);


                DB.Connection();
                OleDbCommand komut = new OleDbCommand($"delete from evsahibibasvuru where id = {id}", DB.connection);
                komut.ExecuteNonQuery();

                OleDbCommand komut2 = new OleDbCommand("select * from evsahibibasvuru", DB.connection);
                OleDbDataReader reader = komut2.ExecuteReader();
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