using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.WebPages.OAuth;
using ma.Models;

namespace ma
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            OAuthWebSecurity.RegisterFacebookClient(
                appId: "606833272667520",
                appSecret: "cc79d6378f87b3b7502c35df31716dd0");
        }
    }
}
