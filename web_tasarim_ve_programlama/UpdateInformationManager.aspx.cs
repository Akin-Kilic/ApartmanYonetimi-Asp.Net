using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using web_tasarim_ve_programlama.DataAccess;
using web_tasarim_ve_programlama.sha;

namespace web_tasarim_ve_programlama.ApartmanIslemleri
{
    public partial class UpdateInformationManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["yonetici"]) == true)
            {
                int apartmanId = Convert.ToInt32(Session["yoneticiapartmanid"].ToString());
                try
                {
                    DB.Connection();
                    int id = Convert.ToInt32(Session["yoneticiid"].ToString());
                    OleDbCommand komut = new OleDbCommand($"select * from users where id={id}", DB.connection);
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

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                Button buton = (Button)sender;
                DataListItem item = (DataListItem)buton.NamingContainer;
                Label labelID = (Label)item.FindControl("lblId");
                int id = Convert.ToInt32(labelID.Text);
                TextBox txtBoxAd = (TextBox)item.FindControl("txtboxIsim");
                string ad = Convert.ToString(txtBoxAd.Text);
                TextBox txtBoxSoyad = (TextBox)item.FindControl("txtboxSoyisim");
                string soyad = Convert.ToString(txtBoxSoyad.Text);
                TextBox txtBoxKullaniciAdi = (TextBox)item.FindControl("txtboxKullaniciAdi");
                string kullaniciAdi = Convert.ToString(txtBoxKullaniciAdi.Text);
                TextBox txtBoxEmail = (TextBox)item.FindControl("txtboxEmail");
                string email = Convert.ToString(txtBoxEmail.Text);
                TextBox txtBoxSifre = (TextBox)item.FindControl("txtboxSifre");
                string sifre = Convert.ToString(txtBoxSifre.Text);
                TextBox txtBoxTelNo = (TextBox)item.FindControl("txtboxTelNo");
                string telNo = Convert.ToString(txtBoxTelNo.Text);


                DB.Connection();
                if (sifre != "")
                {
                    string shaPass = Sha256Converter.ComputeSha256Hash(sifre);
                    OleDbCommand komut = new OleDbCommand($"update users set isim = '{ad}', soyisim = '{soyad}', kullanici_adi = '{kullaniciAdi}', email = '{email}', sifre='{shaPass}', telno = '{telNo}' where id = {id}", DB.connection);
                    komut.ExecuteNonQuery();
                }
                else
                {

                    OleDbCommand komut = new OleDbCommand($"update users set isim = '{ad}', soyisim = '{soyad}', kullanici_adi = '{kullaniciAdi}', email = '{email}', telno = '{telNo}' where id = {id} ", DB.connection);
                    komut.ExecuteNonQuery();
                }
                int id2 = Convert.ToInt32(Session["yoneticiid"].ToString());
                OleDbCommand komut2 = new OleDbCommand($"select * from users where id={id2}", DB.connection);
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