﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SubwaySite
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void userButton_Click(object sender, EventArgs e)
        {
            Server.Transfer("UserWeb.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("AdminLoginWeb.aspx");
        }
    }
}