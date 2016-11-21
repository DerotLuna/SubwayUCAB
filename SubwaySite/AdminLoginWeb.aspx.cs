using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SubwaySite
{
    public partial class AdminLoginWeb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string user = userInput.Text;
            string password = passwordInput.Text;
            if (user == "user" && password == "1234")
            {
                Server.Transfer("AdminWeb.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("Default.aspx");
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void passwordInput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}