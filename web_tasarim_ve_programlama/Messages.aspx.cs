using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using web_tasarim_ve_programlama.DataAccess;

namespace web_tasarim_ve_programlama
{
    public partial class Messages : System.Web.UI.Page
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
                        OleDbCommand komut = new OleDbCommand("select * from contact", DB.connection);
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



        protected void CheckboxOkundu_CheckedChanged(object sender, EventArgs e)
        {

            try
            {
                CheckBox checkBox = (CheckBox)sender;
                string deneme = checkBox.Checked.ToString();
                string okunduMu = deneme.ToLower();

                // CheckBox'ın bulunduğu DataListItem'in referansını alın
                DataListItem item = (DataListItem)checkBox.NamingContainer;

                // DataList içindeki Label kontrolünden ID değerini alın
                Label labelID = (Label)item.FindControl("LabelID");

                int id = Convert.ToInt32(labelID.Text);

                DB.Connection();

                OleDbCommand komut = new OleDbCommand($"update contact set okunduMu = {okunduMu} where id = {id}", DB.connection);
                komut.ExecuteNonQuery();
                DB.Disconnection();

                DataList1.DataSource = null;
                DataList1.DataBind();

                DB.Connection();
                OleDbCommand komut2 = new OleDbCommand("select * from contact", DB.connection);
                OleDbDataReader reader = komut2.ExecuteReader();
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

        protected void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                Button buton = (Button)sender;
                DataListItem item = (DataListItem)buton.NamingContainer;
                Label labelID = (Label)item.FindControl("LabelID");
                int id = Convert.ToInt32(labelID.Text);
                DB.Connection();
                OleDbCommand komut = new OleDbCommand($"delete from contact where id = {id}", DB.connection);
                komut.ExecuteNonQuery();
                DB.Disconnection();

                DB.Connection();
                OleDbCommand komut2 = new OleDbCommand("select * from contact", DB.connection);
                OleDbDataReader reader = komut2.ExecuteReader();
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
}