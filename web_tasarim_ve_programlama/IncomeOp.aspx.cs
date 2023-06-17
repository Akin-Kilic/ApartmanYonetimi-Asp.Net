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
    public partial class IncomeOp : System.Web.UI.Page
    {
        decimal toplam;
        int apartmanId;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Convert.ToBoolean(Session["yonetici"]) == true)
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
                        OleDbCommand komut2 = new OleDbCommand($"select sum(miktar) as toplam from incomes where apartman_id = {apartmanId}", DB.connection);
                        object result = komut2.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            toplam = Convert.ToDecimal(result);
                            toplamGelir.Text = toplam.ToString() + " TL";
                        }
                        else
                        {
                            toplam = 0;
                            toplamGelir.Text = toplam.ToString() + " TL";
                        }

                    }
                    OleDbCommand komut3 = new OleDbCommand($"select * from incomes where apartman_id={apartmanId}",DB.connection);
                    OleDbDataReader reader2 = komut3.ExecuteReader();
                    DataList1.DataSource = reader2;
                    DataList1.DataBind();
                    reader2.Close();
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
                Button buton = (Button)sender;
                DataListItem item = (DataListItem)buton.NamingContainer;
                Label labelID = (Label)item.FindControl("lblId");
                int id = Convert.ToInt32(labelID.Text);
                TextBox txtboxBaslik = (TextBox)item.FindControl("txtBaslik");
                string baslik = Convert.ToString(txtboxBaslik.Text);
                TextBox txtboxMiktar = (TextBox)item.FindControl("txtMiktar");
                decimal miktar = Convert.ToDecimal(txtboxMiktar.Text);

                DB.Connection();
                OleDbCommand komut = new OleDbCommand($"update incomes set baslik='{baslik}', miktar={miktar} where id = {id}", DB.connection);
                komut.ExecuteNonQuery();


                int yoneticiId = Convert.ToInt32(Session["yoneticiid"].ToString());
               
                OleDbCommand komut2 = new OleDbCommand($"select apartman_id from users where id={yoneticiId}", DB.connection);
                OleDbDataReader reader = komut2.ExecuteReader();

                if (reader.Read())
                {
                    apartmanId = Convert.ToInt32(reader[0]);
                    reader.Close();
                    OleDbCommand komut3 = new OleDbCommand($"select sum(miktar) as toplam from incomes where apartman_id = {apartmanId}", DB.connection);
                    object result = komut3.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        toplam = Convert.ToDecimal(result);
                        toplamGelir.Text = toplam.ToString() + " TL";
                    }
                    else
                    {
                        toplam = 0;
                        toplamGelir.Text = toplam.ToString() + " TL";
                    }

                }
                OleDbCommand komut4 = new OleDbCommand($"select * from incomes where apartman_id={apartmanId}", DB.connection);
                OleDbDataReader reader2 = komut4.ExecuteReader();
                DataList1.DataSource = reader2;
                DataList1.DataBind();
                reader2.Close();
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
                OleDbCommand komut = new OleDbCommand($"delete from incomes where id = {id}", DB.connection);
                komut.ExecuteNonQuery();


                int yoneticiId = Convert.ToInt32(Session["yoneticiid"].ToString());
                
                OleDbCommand komut2 = new OleDbCommand($"select apartman_id from users where id={yoneticiId}", DB.connection);
                OleDbDataReader reader = komut2.ExecuteReader();

                if (reader.Read())
                {
                    int apartmanId = Convert.ToInt32(reader[0]);
                    reader.Close();
                    OleDbCommand komut3 = new OleDbCommand($"select sum(miktar) as toplam from incomes where apartman_id = {apartmanId}", DB.connection);
                    object result = komut3.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        toplam = Convert.ToDecimal(result);
                        toplamGelir.Text = toplam.ToString() + " TL";
                    }
                    else
                    {
                        toplam = 0;
                        toplamGelir.Text = toplam.ToString() + " TL";
                    }

                }
                OleDbCommand komut4 = new OleDbCommand($"select * from incomes where apartman_id = {apartmanId}", DB.connection);
                OleDbDataReader reader2 = komut4.ExecuteReader();
                DataList1.DataSource = reader2;
                DataList1.DataBind();
                reader2.Close();
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