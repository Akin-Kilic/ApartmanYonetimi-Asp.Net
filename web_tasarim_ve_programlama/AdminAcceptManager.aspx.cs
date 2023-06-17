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
    public partial class AdminAcceptManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["admin"]) == true)
            {
                if (!IsPostBack)
                {
                    try
                    {
                        DB.Connection();
                        OleDbCommand komut = new OleDbCommand("select * from yoneticibasvuru", DB.connection);
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
                        OleDbCommand komut = new OleDbCommand("select * from yoneticibasvuru", DB.connection);
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


        protected void btnReddet_Click(object sender, EventArgs e)
        {
            try
            {
                Button buton = (Button)sender;
                DataListItem item = (DataListItem)buton.NamingContainer;
                Label labelID = (Label)item.FindControl("LabelID");
                int id = Convert.ToInt32(labelID.Text);


                DB.Connection();
                OleDbCommand komut = new OleDbCommand($"delete from yoneticibasvuru where id = {id}", DB.connection);
                komut.ExecuteNonQuery();

                OleDbCommand komut2 = new OleDbCommand("select * from yoneticibasvuru", DB.connection);
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

        protected void btnOnayla_Click(object sender, EventArgs e)
        {
            //string email;
            try
            {
                Button buton = (Button)sender;
                DataListItem item = (DataListItem)buton.NamingContainer;
                Label labelID = (Label)item.FindControl("LabelID");
                int id = Convert.ToInt32(labelID.Text);
                Label lblAd = (Label)item.FindControl("LabelAd");
                string ad = Convert.ToString(lblAd.Text);
                Label lblSoyad = (Label)item.FindControl("LabelSoyad");
                string soyad = Convert.ToString(lblSoyad.Text);
                Label lblKullaniciAdi = (Label)item.FindControl("LabelKullaniciAdi");
                string kullaniciAdi = Convert.ToString(lblKullaniciAdi.Text);
                Label lblSifre = (Label)item.FindControl("LabelSifre");
                string sifre = Convert.ToString(lblSifre.Text);
                Label lblEmail = (Label)item.FindControl("LabelEposta");
                string email = Convert.ToString(lblEmail.Text);
                Label lblApartmanAdi = (Label)item.FindControl("LabelApartmanAdi");
                string apartmanAdi = Convert.ToString(lblApartmanAdi.Text);
                Label lblIl = (Label)item.FindControl("LabelIl");
                string il = Convert.ToString(lblIl.Text);
                Label lblIlce = (Label)item.FindControl("LabelIlce");
                string ilce = Convert.ToString(lblIlce.Text);
                Label lblMahalle = (Label)item.FindControl("LabelMahalle");
                string mahalle = Convert.ToString(lblMahalle.Text);
                Label lblCadde = (Label)item.FindControl("LabelCadde");
                string cadde = Convert.ToString(lblCadde.Text);
                Label lblApartmanNo = (Label)item.FindControl("LabelApartmanNo");
                string apartmanNo = Convert.ToString(lblApartmanNo.Text);
                Label lblTelNo = (Label)item.FindControl("LabelTelNo");
                string telNo = Convert.ToString(lblTelNo.Text);

                string adres = il + ", " + ilce + ", " + mahalle + ", " + cadde;

                DB.Connection();
                OleDbCommand komut4 = new OleDbCommand($"insert into apartments (apartman_adi, adres, apartman_no, dues) values ('{apartmanAdi}', '{adres}', '{apartmanNo}', {0})", DB.connection);
                komut4.ExecuteNonQuery();
                DB.Disconnection();

                DB.Connection();
                OleDbCommand komut5 = new OleDbCommand("select max(id) from apartments", DB.connection);
                int lastID = Convert.ToInt32(komut5.ExecuteScalar());
                DB.Disconnection();


                DB.Connection();
                OleDbCommand komut3 = new OleDbCommand($"insert into users (isim, soyisim, kullanici_adi, email, sifre, telno, tip, apartman_id) values ('{ad}', '{soyad}', '{kullaniciAdi}', '{email}', '{sifre}', '{telNo}', 1, {lastID})", DB.connection);
                komut3.ExecuteNonQuery();
                DB.Disconnection();



                DB.Connection();
                OleDbCommand komut = new OleDbCommand($"delete from yoneticibasvuru where id = {id}", DB.connection);
                komut.ExecuteNonQuery();

                OleDbCommand komut2 = new OleDbCommand("select * from yoneticibasvuru", DB.connection);
                OleDbDataReader reader = komut2.ExecuteReader();
                DataList1.DataSource = reader;
                DataList1.DataBind();
                reader.Close();
                DB.Disconnection();
            }
            catch (Exception)
            {

                throw;
            }
            finally { DB.Disconnection(); }

        }
    }
}