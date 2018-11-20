using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQLConnectionWebApp.Models
{
    public class user
    {
        bool loggedIn = false;
        string username;

        public string Username { get => username; set => username = value; }
        public bool LoggedIn { get => loggedIn; set => loggedIn = value; }

        public static user getUser()
        {
            var userSelection = (user)HttpContext.Current.Session["user"];
            if (userSelection == null)
            {
                HttpContext.Current.Session.Add("user", new user());
                userSelection = (user)HttpContext.Current.Session["user"];
            }
            return userSelection;
        }
    }
}