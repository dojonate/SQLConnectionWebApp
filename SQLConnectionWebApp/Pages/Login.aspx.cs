using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SQLConnectionWebApp.Models
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        user User;
        protected void Page_Load(object sender, EventArgs e)
        {
            User = user.getUser();
            if (User.LoggedIn == true)
            {
                loginControls.Visible = false;
                loggedInControls.Visible = true;
                successLbl.Text += User.Username;
            }

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            string ConnString = ConfigurationManager.ConnectionStrings["c432018fa01dillnConnectionString"].ConnectionString;
            string SqlQuery = "SELECT password FROM Users WHERE username=@username";
            try
            {
                // create connection and command objects
                SqlConnection cnn = new SqlConnection(ConnString);
                SqlCommand cmd = new SqlCommand(SqlQuery, cnn);
                // define parameters and their values
                
                cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = username.Text;
                // open connection, execute SELECT, close connection
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.GetValue(0).ToString() == password.Text)
                {
                    User.LoggedIn = true;
                    User.Username = username.Text;
                } else
                {
                    lblErrorMessage.Text = "Incorrect Password!";
                    lblErrorMessage.Visible = true;
                }
                reader.Close();
                cmd.Dispose();
                cnn.Close();

                Response.Redirect("~/Pages/Login.aspx");
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = "Invalid Username!";
                lblErrorMessage.Visible = true;
            }
        }
    }
}