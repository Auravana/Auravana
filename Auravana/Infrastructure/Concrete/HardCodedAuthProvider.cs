using Auravana.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Auravana.Infrastructure.Concrete
{
    public class HardCodedAuthProvider : IAuthProvider
    {
        public bool Authenticate(string username, string password)
        {
            bool authenticated = false;

            switch(username.ToLowerInvariant())
            {
                case "captainbedpan":
                case "travis":  
                case "mutterbuttocks":
                    authenticated = true;
                    break;
            }

            if (authenticated){
                FormsAuthentication.SetAuthCookie(username, false);
            }

            return authenticated;
        }
    }
}