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
    public partial class CashOp : System.Web.UI.Page
    {
        int apartmanId;
        decimal toplamGelir;
        decimal toplamGider;
        decimal kasa;
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
                        OleDbCommand komut2 = new OleDbCommand($"select sum(miktar) as toplamgelir from incomes where apartman_id = {apartmanId}", DB.connection);
                        object result = komut2.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            toplamGelir = Convert.ToDecimal(result);
                        }
                        else
                        {
                            toplamGelir = 0;
                        }

                        OleDbCommand komut3 = new OleDbCommand($"select sum(miktar) as toplam from expenses where apartman_id = {apartmanId}", DB.connection);
                        object result2 = komut3.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            toplamGider = Convert.ToDecimal(result2);
                        }
                        else
                        {
                            toplamGider = 0;
                        }

                    }
                    kasa = toplamGelir - toplamGider;
                    lblKasa.Text = kasa.ToString()+" TL";
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
    }
}