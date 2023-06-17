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
    public partial class Income : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["evsahibi"]) == true)
            {
                int apartmanId = Convert.ToInt32(Session["evsahibiapartmanid"].ToString());
                try
                {
                    DB.Connection();
                    OleDbCommand komut = new OleDbCommand($"select sum(miktar) from incomes where apartman_id = {apartmanId}", DB.connection);
                    OleDbDataReader reader = komut.ExecuteReader();
                    if (reader.Read())
                    {
                        int miktar = Convert.ToInt32(reader[0].ToString());
                        lblIncome.Text = "Gelirler Toplam: " + miktar.ToString() + " TL";
                    }

                    OleDbCommand komut2 = new OleDbCommand($"select * from incomes where apartman_id={apartmanId}", DB.connection);
                    OleDbDataReader reader2 = komut2.ExecuteReader();
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
    }
}