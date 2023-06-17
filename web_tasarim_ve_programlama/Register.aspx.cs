using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using web_tasarim_ve_programlama.DataAccess;
using web_tasarim_ve_programlama.sha;
using System.Data;

namespace web_tasarim_ve_programlama
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Şehir verilerini doldur
                ddlSehirler.DataSource = GetSehirler(); // Veritabanından veya başka bir kaynaktan şehir verilerini alın
                ddlSehirler.DataTextField = "SehirAdi"; // Şehir adını gösteren sütun adı
                ddlSehirler.DataValueField = "SehirID"; // Şehir ID'sini tutan sütun adı
                ddlSehirler.DataBind();

                ddlSehirler2.DataSource = GetSehirler(); // Veritabanından veya başka bir kaynaktan şehir verilerini alın
                ddlSehirler2.DataTextField = "SehirAdi"; // Şehir adını gösteren sütun adı
                ddlSehirler2.DataValueField = "SehirID"; // Şehir ID'sini tutan sütun adı
                ddlSehirler2.DataBind();
            }
        }

        protected void ddlSehirler_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sehirID = ddlSehirler.SelectedValue;

            if (!string.IsNullOrEmpty(sehirID))
            {
                // İlçe verilerini doldur
                ddlIlceler.DataSource = GetIlceler(sehirID); // Veritabanından veya başka bir kaynaktan ilçe verilerini alın
                ddlIlceler.DataTextField = "IlceAdi"; // İlçe adını gösteren sütun adı
                ddlIlceler.DataValueField = "IlceID"; // İlçe ID'sini tutan sütun adı
                ddlIlceler.DataBind();

                ddlIlceler.Enabled = true;
            }
            else
            {
                ddlIlceler.Enabled = false;
                ddlMahalleler.Enabled = false;
                ddlSokaklar.Enabled = false;
            }
        }

        protected void ddlIlceler_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ilceID = ddlIlceler.SelectedValue;

            if (!string.IsNullOrEmpty(ilceID))
            {
                // Mahalle verilerini doldur
                ddlMahalleler.DataSource = GetMahalleler(ilceID); // Veritabanından veya başka bir kaynaktan mahalle verilerini alın
                ddlMahalleler.DataTextField = "MahalleAdi"; // Mahalle adını gösteren sütun adı
                ddlMahalleler.DataValueField = "MahalleID"; // Mahalle ID'sini tutan sütun adı
                ddlMahalleler.DataBind();

                ddlMahalleler.Enabled = true;
            }
            else
            {
                ddlMahalleler.Enabled = false;
                ddlSokaklar.Enabled = false;
            }
        }

        protected void ddlMahalleler_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mahalleID = ddlMahalleler.SelectedValue;

            if (!string.IsNullOrEmpty(mahalleID))
            {
                // Sokak verilerini doldur
                ddlSokaklar.DataSource = GetSokaklar(mahalleID); // Veritabanından veya başka bir kaynaktan sokak verilerini alın
                ddlSokaklar.DataTextField = "SokakAdi"; // Sokak adını gösteren sütun adı
                ddlSokaklar.DataValueField = "SokakID"; // Sokak ID'sini tutan sütun adı
                ddlSokaklar.DataBind();

                ddlSokaklar.Enabled = true;
            }
            else
            {
                ddlSokaklar.Enabled = false;
            }
        }

        protected void ddlSehirler2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sehirID = ddlSehirler2.SelectedValue;

            if (!string.IsNullOrEmpty(sehirID))
            {
                // İlçe verilerini doldur
                ddlIlceler2.DataSource = GetIlceler(sehirID); // Veritabanından veya başka bir kaynaktan ilçe verilerini alın
                ddlIlceler2.DataTextField = "IlceAdi"; // İlçe adını gösteren sütun adı
                ddlIlceler2.DataValueField = "IlceID"; // İlçe ID'sini tutan sütun adı
                ddlIlceler2.DataBind();

                ddlIlceler2.Enabled = true;
            }
            else
            {
                ddlIlceler2.Enabled = false;
                ddlMahalleler2.Enabled = false;
                ddlSokaklar2.Enabled = false;
            }
        }

        protected void ddlIlceler2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ilceID = ddlIlceler2.SelectedValue;

            if (!string.IsNullOrEmpty(ilceID))
            {
                // Mahalle verilerini doldur
                ddlMahalleler2.DataSource = GetMahalleler(ilceID); // Veritabanından veya başka bir kaynaktan mahalle verilerini alın
                ddlMahalleler2.DataTextField = "MahalleAdi"; // Mahalle adını gösteren sütun adı
                ddlMahalleler2.DataValueField = "MahalleID"; // Mahalle ID'sini tutan sütun adı
                ddlMahalleler2.DataBind();

                ddlMahalleler2.Enabled = true;
            }
            else
            {
                ddlMahalleler2.Enabled = false;
                ddlSokaklar2.Enabled = false;
            }
        }

        protected void ddlMahalleler2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mahalleID = ddlMahalleler2.SelectedValue;

            if (!string.IsNullOrEmpty(mahalleID))
            {
                // Sokak verilerini doldur
                ddlSokaklar2.DataSource = GetSokaklar(mahalleID); // Veritabanından veya başka bir kaynaktan sokak verilerini alın
                ddlSokaklar2.DataTextField = "SokakAdi"; // Sokak adını gösteren sütun adı
                ddlSokaklar2.DataValueField = "SokakID"; // Sokak ID'sini tutan sütun adı
                ddlSokaklar2.DataBind();

                ddlSokaklar2.Enabled = true;
            }
            else
            {
                ddlSokaklar2.Enabled = false;
            }
        }

        protected void ddlSokaklar2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlApartman.Items.Clear();
            ddlApartman.Items.Add(new ListItem("-- Apartman Seç --"));
            string adres = ddlSehirler2.SelectedItem.Text + ", " + ddlIlceler2.SelectedItem.Text + ", " + ddlMahalleler2.SelectedItem.Text + ", " + ddlSokaklar2.SelectedItem.Text;
            try
            {
                DB.Connection();
                OleDbCommand komut = new OleDbCommand($"select * from apartments where adres='{adres}'", DB.connection);
                OleDbDataReader reader = komut.ExecuteReader();

                if (reader.Read())
                {

                    while (reader.Read())
                    {
                        string apartmentName = reader["apartman_adi"].ToString();
                        string apartmentId = reader["id"].ToString();
                        ddlApartman.Items.Add(new ListItem(apartmentName, apartmentId));
                    }
                }
                reader.Close();
                ddlApartman.Enabled = true;
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

        protected void ddlApartman_SelectedIndexChanged(object sender, EventArgs e)
        {

            ddlDaireNo.Items.Clear();
            ddlDaireNo.Items.Add(new ListItem("-- Daire Seç --"));
            int apartmanId = Convert.ToInt32(ddlApartman.SelectedItem.Value);
            try
            {
                DB.Connection();
                OleDbCommand komut = new OleDbCommand($"select * from flats where apartman_id = {apartmanId} and bosMu = {false}", DB.connection);
                OleDbDataReader reader = komut.ExecuteReader();
                if (reader.Read())
                {
                    while (reader.Read())
                    {
                        string daireNo = reader["daire_no"].ToString();
                        ddlDaireNo.Items.Add(new ListItem(daireNo));
                    }
                }
                reader.Close();
                ddlDaireNo.Enabled = true;
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

        // Şehir verilerini döndüren metot
        protected DataTable GetSehirler()
        {
            // Şehir verilerini veritabanından veya başka bir kaynaktan alıp DataTable olarak döndürün
            // Örnek veriler oluşturmak için aşağıdaki kodu kullanabilirsiniz:

            DataTable dtSehirler = new DataTable();
            dtSehirler.Columns.Add("SehirID", typeof(int));
            dtSehirler.Columns.Add("SehirAdi", typeof(string));

            dtSehirler.Rows.Add(null, "--bir şehir seçiniz--");
            dtSehirler.Rows.Add(1, "İstanbul");
            dtSehirler.Rows.Add(2, "Ankara");
            dtSehirler.Rows.Add(3, "İzmir");
            dtSehirler.Rows.Add(60, "Tokat");
            // Diğer şehirler...

            return dtSehirler;
        }

        // İlçe verilerini döndüren metot
        protected DataTable GetIlceler(string sehirID)
        {
            // İlçe verilerini veritabanından veya başka bir kaynaktan alıp DataTable olarak döndürün
            // Seçilen şehir ID'sine göre ilgili ilçeleri getirebilirsiniz

            DataTable dtIlceler = new DataTable();
            dtIlceler.Columns.Add("IlceID", typeof(int));
            dtIlceler.Columns.Add("IlceAdi", typeof(string));

            if (sehirID == "1") // İstanbul için ilçe verileri
            {
                dtIlceler.Rows.Add(101, "Beşiktaş");
                dtIlceler.Rows.Add(102, "Kadıköy");
                dtIlceler.Rows.Add(103, "Şişli");
                // Diğer ilçeler...
            }
            else if (sehirID == "2") // Ankara için ilçe verileri
            {
                dtIlceler.Rows.Add(201, "Çankaya");
                dtIlceler.Rows.Add(202, "Keçiören");
                dtIlceler.Rows.Add(203, "Yenimahalle");
                // Diğer ilçeler...
            }
            else if (sehirID == "3") // İzmir için ilçe verileri
            {
                dtIlceler.Rows.Add(301, "Konak");
                dtIlceler.Rows.Add(302, "Buca");
                dtIlceler.Rows.Add(303, "Karşıyaka");
                // Diğer ilçeler...
            }
            else if (sehirID == "60") // Tokat için ilçe verileri
            {
                dtIlceler.Rows.Add(601, "Erbaa");
                dtIlceler.Rows.Add(602, "Niksar");
                dtIlceler.Rows.Add(603, "Pazar");
                // Diğer ilçeler...
            }
            // Diğer şehirler için ilçe verileri...

            return dtIlceler;
        }

        // Mahalle verilerini döndüren metot
        protected DataTable GetMahalleler(string ilceID)
        {
            // Mahalle verilerini veritabanından veya başka bir kaynaktan alıp DataTable olarak döndürün
            // Seçilen ilçe ID'sine göre ilgili mahalleleri getirebilirsiniz

            DataTable dtMahalleler = new DataTable();
            dtMahalleler.Columns.Add("MahalleID", typeof(int));
            dtMahalleler.Columns.Add("MahalleAdi", typeof(string));

            if (ilceID == "101") // Beşiktaş için mahalle verileri
            {
                dtMahalleler.Rows.Add(1001, "Abbasağa");
                dtMahalleler.Rows.Add(1002, "Arnavutköy");
                dtMahalleler.Rows.Add(1003, "Bebek");
                // Diğer mahalleler...
            }
            else if (ilceID == "102") // Kadıköy için mahalle verileri
            {
                dtMahalleler.Rows.Add(2001, "Acıbadem");
                dtMahalleler.Rows.Add(2002, "Bostancı");
                dtMahalleler.Rows.Add(2003, "Caddebostan");
                // Diğer mahalleler...
            }
            else if (ilceID == "103") // Şişli için mahalle verileri
            {
                dtMahalleler.Rows.Add(3001, "Abide-i Hürriyet");
                dtMahalleler.Rows.Add(3002, "Ergenekon");
                dtMahalleler.Rows.Add(3003, "Harbiye");
                // Diğer mahalleler...
            }
            else if (ilceID == "602") // Şişli için mahalle verileri
            {
                dtMahalleler.Rows.Add(6001, "Ayvaz");
                dtMahalleler.Rows.Add(6002, "Fatih");
                dtMahalleler.Rows.Add(6003, "Kültür");
                // Diğer mahalleler...
            }

            // Diğer ilçeler için mahalle verileri...

            return dtMahalleler;
        }

        // Sokak verilerini döndüren metot
        protected DataTable GetSokaklar(string mahalleID)
        {
            // Sokak verilerini veritabanından veya başka bir kaynaktan alıp DataTable olarak döndürün
            // Seçilen mahalle ID'sine göre ilgili sokakları getirebilirsiniz

            DataTable dtSokaklar = new DataTable();
            dtSokaklar.Columns.Add("SokakID", typeof(int));
            dtSokaklar.Columns.Add("SokakAdi", typeof(string));

            if (mahalleID == "1001") // Abbasağa için sokak verileri
            {
                dtSokaklar.Rows.Add(5001, "Abbasağa Caddesi");
                dtSokaklar.Rows.Add(5002, "Abbasağa Sokak");
                dtSokaklar.Rows.Add(5003, "Abbasağa Meydanı");
                // Diğer sokaklar...
            }
            else if (mahalleID == "1002") // Arnavutköy için sokak verileri
            {
                dtSokaklar.Rows.Add(6001, "Arnavutköy Caddesi");
                dtSokaklar.Rows.Add(6002, "Arnavutköy Sokak");
                dtSokaklar.Rows.Add(6003, "Arnavutköy Meydanı");
                // Diğer sokaklar...
            }
            else if (mahalleID == "1003") // Bebek için sokak verileri
            {
                dtSokaklar.Rows.Add(7001, "Bebek Caddesi");
                dtSokaklar.Rows.Add(7002, "Bebek Sokak");
                dtSokaklar.Rows.Add(7003, "Bebek Meydanı");
                // Diğer sokaklar...
            }
            else if (mahalleID == "6002") // Bebek için sokak verileri
            {
                dtSokaklar.Rows.Add(60001, "Güven Sokak");
                dtSokaklar.Rows.Add(60002, "9. Sokak");
                dtSokaklar.Rows.Add(60003, "Şht. Er Duran Kabakçı Sokak");
                // Diğer sokaklar...
            }
            // Diğer mahalleler için sokak verileri...

            return dtSokaklar;
        }

        protected void rbUserType_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton selectedRadioButton = (RadioButton)sender;

            if (selectedRadioButton == rbYonetici)
            {
                pnlYonetici.Visible = true;
                pnlEvSahibi.Visible = false;
            }
            else if (selectedRadioButton == rbEvSahibi)
            {
                pnlEvSahibi.Visible = true;
                pnlYonetici.Visible = false;
            }
            else
            {
                pnlYonetici.Visible = false;
                pnlEvSahibi.Visible = false;
            }
        }





        protected void KayitOlButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (rfvYoneticiAd.IsValid &&
            rfvYoneticiSoyad.IsValid &&
            rfvYoneticiKullaniciAdi.IsValid &&
            rfvYoneticiSifre.IsValid &&
            rfvYoneticiEmail.IsValid &&
            rfvYoneticiTelNo.IsValid &&
            rfvYoneticiApartmanAdi.IsValid &&
            rfvYoneticiApartmanNo.IsValid)
                {
                    string shaPass = Sha256Converter.ComputeSha256Hash(txtYoneticiSifre.Text);
                    string sehir = ddlSehirler.SelectedItem.Text;
                    string ilce = ddlIlceler.SelectedItem.Text;
                    string mahalle = ddlMahalleler.SelectedItem.Text;
                    string sokak = ddlSokaklar.SelectedItem.Text;
                    DB.Connection();
                    string query = $"insert into yoneticibasvuru (ad, soyad, kullaniciadi, sifre, email, apartmanadi, " +
                        $"il, ilce, mahalle, cadde, apartmanno, telno) values ('{txtYoneticiAd.Text}', '{txtYoneticiSoyad.Text}'," +
                        $"'{txtYoneticiKullaniciAdi.Text}','{shaPass}','{txtYoneticiEmail.Text}', '{txtYoneticiApartmanAdi.Text}', " +
                        $"'{sehir}', '{ilce}','{mahalle}','{sokak}','{txtYoneticiApartmanNo.Text}','{txtYoneticiTelNo.Text}')";
                    OleDbCommand command = new OleDbCommand(query, DB.connection);
                    command.ExecuteNonQuery();
                    string script = "showManagerSuccess();";
                    ScriptManager.RegisterStartupScript(this, GetType(), "showManagerSuccess", script, true);
                }
            }
            catch (Exception ex)
            { Response.Write(ex.Message); }
            finally { DB.Disconnection(); }

        }

        protected void btnEvSahibiKayit_Click(object sender, EventArgs e)
        {
            try
            {

                if (rfvEvSahibiAd.IsValid &&
rfvYoneticiSoyad.IsValid &&
rfvEvSahibiKullaniciAdi.IsValid &&
rfvEvSahibiSifre.IsValid &&
rfvEvSahibiEmail.IsValid &&
rfvEvSahibiTelNo.IsValid)
                {
                    int daireNo = Convert.ToInt32(ddlDaireNo.SelectedItem.Text);

                    string shaPass = Sha256Converter.ComputeSha256Hash(txtEvSahibiSifre.Text);
                    DB.Connection();

                    int apartmanId = Convert.ToInt32(ddlApartman.SelectedItem.Value);

                    OleDbCommand komut = new OleDbCommand($"insert into evsahibibasvuru (isim, soyisim, kullaniciadi, email, sifre, telno, daire, apartman_id) values ('{txtEvSahibiAd.Text}', '{txtEvSahibiSoyad.Text}', '{txtEvSahibiKullaniciAdi.Text}', '{txtEvSahibiEmail.Text}', '{shaPass}', '{txtEvSahibiTelNo.Text}', {daireNo}, {apartmanId})", DB.connection);
                    komut.ExecuteNonQuery();
                    string script = "showHomeownerSuccess();";
                    ScriptManager.RegisterStartupScript(this, GetType(), "showHomeownerSuccess", script, true);
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