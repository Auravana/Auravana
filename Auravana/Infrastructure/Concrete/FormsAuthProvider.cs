using Auravana.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Auravana.Infrastructure.Concrete
{
    public class FormsAuthProvider : IAuthProvider
    {
        public bool Authenticate(string username, string password)
        {
            bool authenticated = Membership.ValidateUser(username, password);

            if (authenticated)
            {
                FormsAuthentication.SetAuthCookie(username, false);
            }

            return authenticated;
        }
    }
}