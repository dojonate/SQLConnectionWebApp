using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SQLConnectionWebApp.Models
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        user User;


        protected void Page_Load(object sender, EventArgs e)
        {
            User = user.getUser();
            if (User.LoggedIn == false)
            {
                loggedOut.Visible = true;
                HtmlMeta meta = new HtmlMeta();
                meta.HttpEquiv = "Refresh";
                meta.Content = "10;url=Login.aspx";
                this.Page.Controls.Add(meta);
            }
            else
            {
                loggedIn.Visible = true;
                Get_User_Data();
            }
        }

        private void Get_User_Data()
        {
            string ConnString = ConfigurationManager.ConnectionStrings["c432018fa01dillnConnectionString"].ConnectionString;
            string SqlQuery = "SELECT * FROM Users WHERE username=@username";
            try
            {
                // create connection and command objects
                SqlConnection cnn = new SqlConnection(ConnString);
                SqlCommand cmd = new SqlCommand(SqlQuery, cnn);
                // define parameters and their values
                cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = User.Username;
                // open connection, execute SELECT, close connection
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                object[] userValues = new object[reader.FieldCount];
                reader.GetValues(userValues);

                // assign values to fields
                usernamePrintLbl.Text = userValues[0].ToString();
                lastName.Text = userValues[2].ToString();
                firstName.Text = userValues[3].ToString();
                address.Text = userValues[4].ToString();
                birthDate.Text = userValues[5].ToString();
                phoneNumber.Text = userValues[6].ToString();

                reader.Close();
                cmd.Dispose();
                cnn.Close();
            }
            catch (Exception ex)
            {
                /*lblErrorMessage.Text = "Invalid Username!";
                lblErrorMessage.Visible = true;*/
            }
        }

        protected void saveUpdates_Click(object sender, EventArgs e)
        {
            string ConnString = ConfigurationManager.ConnectionStrings["c432018fa01dillnConnectionString"].ConnectionString;
            string SqlQuery = "Update Users SET password=@password, lastName = @lastName, " +
                "firstName = @firstName, address = @address, birthDate = @birthDate, " +
                "phone = @phone WHERE username = @username";
            try
            {
                // create connection and command objects
                SqlConnection cnn = new SqlConnection(ConnString);
                SqlCommand cmd = new SqlCommand(SqlQuery, cnn);
                // define parameters and their values
                cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = User.Username;
                if (newPassword.Text == "" && confirmPassword.Text == "")
                {
                    cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = oldPassword.Text;
                } else
                {
                    cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = newPassword.Text;
                }
                cmd.Parameters.Add("@lastName", SqlDbType.VarChar).Value = lastName.Text;
                cmd.Parameters.Add("@firstName", SqlDbType.VarChar).Value = firstName.Text;
                cmd.Parameters.Add("@address", SqlDbType.VarChar).Value = address.Text;
                cmd.Parameters.Add("@birthDate", SqlDbType.VarChar).Value = DateTime.Parse(birthDate.Text).Date.ToString("yyyy'-'MM'-'dd");
                cmd.Parameters.Add("@phone", SqlDbType.VarChar).Value = phoneNumber.Text;

                // open connection, execute SELECT, close connection
                cnn.Open();

                cmd.ExecuteNonQuery();
                
                cnn.Close();
                Response.Redirect("~/Pages/MyAccount.aspx");
            }
            catch (Exception ex)
            {
                /*lblErrorMessage.Text = "Invalid Username!";
                lblErrorMessage.Visible = true;*/
            }
        }

        protected void newPasswordChecker_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Length <= 8) {
                newPasswordChecker.Text = "Password must be at least 8 characters";
                args.IsValid = false;
            } else if (!args.Value.Any(char.IsUpper))
            {
                newPasswordChecker.Text = "Password contain a capital letter";
                args.IsValid = false;
            } else if (!args.Value.Any(char.IsNumber))
            {
                newPasswordChecker.Text = "Password must contain a number";
                args.IsValid = false;
            } else if (!(args.Value.Any(char.IsPunctuation) || args.Value.Any(char.IsSymbol)))
            {
                newPasswordChecker.Text = "Password must contain a special character";
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }
    }
}