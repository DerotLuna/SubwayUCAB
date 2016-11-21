using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SubwaySite
{
    public partial class UserWeb : System.Web.UI.Page
    {
        //private List<Line> subway;
        //private WebApplication4.WebService1 subwayServer;

        protected void Page_Load(object sender, EventArgs e)
        {
            //subwayServer = new WebService1();
            //subway = subwayServer.getSubway();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("Default.aspx");
        }

        protected void disabler_Click(object sender, EventArgs e)
        {

        }
    }
}