using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using web_tasarim_ve_programlama.DataAccess;

namespace web_tasarim_ve_programlama
{
    public partial class ContactUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                DB.Connection();
                OleDbCommand komut = new OleDbCommand("insert into contact (mesaj, email, isim, okunduMu) values (@mesaj, @email, @isim, @okunduMu)", DB.connection);
                komut.Parameters.AddWithValue("@mesaj", tboxMesaj.Text);
                komut.Parameters.AddWithValue("@email", tboxEmail.Text);
                komut.Parameters.AddWithValue("@isim", tboxIsim.Text);
                komut.Parameters.AddWithValue("@okunduMu", false);
                komut.ExecuteNonQuery();
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