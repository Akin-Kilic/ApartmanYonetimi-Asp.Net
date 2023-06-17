using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using web_tasarim_ve_programlama.DataAccess;

namespace web_tasarim_ve_programlama.Homeowner
{
    public partial class Cash : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["evsahibi"]) == true)
            {
                try
                {
                    int cash = 0;
                    int apartmanId = Convert.ToInt32(Session["evsahibiapartmanid"].ToString());
                    DB.Connection();
                    OleDbCommand komut = new OleDbCommand($"select sum(miktar) as toplamgelir from incomes where apartman_id = {apartmanId}", DB.connection);
                    OleDbDataReader reader = komut.ExecuteReader();

                    if (reader.Read())
                    {
                        cash += Convert.ToInt32(reader[0].ToString());
                        reader.Close();
                        OleDbCommand komut2 = new OleDbCommand($"select sum(miktar) as toplamgider from expenses where apartman_id = {apartmanId}", DB.connection);
                        OleDbDataReader reader2 = komut2.ExecuteReader();
                        if (reader2.Read())
                        {
                            cash -= Convert.ToInt32(reader2[0].ToString());
                            reader2.Close();
                        }
                    }
                    lblKasa.Text = "Kasa Toplam: " + cash + " TL";
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