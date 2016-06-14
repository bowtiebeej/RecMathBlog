﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using RecMath;
using RecMath.Providers;

namespace RecMath.Providers
{
    public class AuthProvider : IAuthProvider
    {
        public bool IsLoggedIn
        {
            get
            {
                return HttpContext.Current.User.Identity.IsAuthenticated;
            }
        }

        public bool Login(string username, string password)
        {
            bool result = Membership.ValidateUser(username, password); //TODO: User Membership APIs

            if (result)
                FormsAuthentication.SetAuthCookie(username, false);

            return result;
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }
    }
}