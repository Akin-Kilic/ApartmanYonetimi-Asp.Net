using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web_tasarim_ve_programlama
{
    public partial class AdminAnasayfa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["admin"]) == true)
            {

            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}