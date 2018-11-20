using SQLConnectionWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SQLConnectionWebApp
{
    public partial class master : System.Web.UI.MasterPage
    {
        user User;
        protected void Page_Load(object sender, EventArgs e)
        {
            User = user.getUser();
            if (User.LoggedIn == true)
            {
                logout.Visible = true;
            }
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            User.LoggedIn = false;
            User.Username = "";
            
            Response.Redirect("~/Pages/Login.aspx");
        }
    }
}