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
                appId: "122416341281934",
                appSecret: "652f8f3390f0e376f43d73bca00a183b");
        }
    }
}
