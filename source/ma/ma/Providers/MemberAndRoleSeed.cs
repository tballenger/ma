using ma.Areas.Account.Models;
using ma.Models.Helpers;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using WebMatrix.WebData;

namespace ma.Providers
{
    public class MemberAndRoleSeed
    {
        public static void Seed()
        {
            bool seedMembership = false;

            var setting = ConfigurationManager.AppSettings["SeedMembership"];
            if(setting != null)
                seedMembership = true; //if the section is there, consider it TRUE.

            if (seedMembership)
            {
                if (!Roles.RoleExists("Administrator"))
                    Roles.CreateRole("Administrator");

                if (!Roles.RoleExists("Deleted"))
                    Roles.CreateRole("Deleted");

                if (!WebSecurity.UserExists("tom.albers@iteration35.com"))
                    WebSecurity.CreateUserAndAccount(
                        "tom.albers@iteration35.com",
                        "0000", //this will be changed quickly
                        new
                        {
                            Mobile = "949.400.6909",
                            FullName = "Tom Albers",
                            Link = "http://www.facebook.com/alberstt",
                            Verified = true,
                            FbUserId = "1234567890", //"1355951794" - I want ensure this gets overriden when the real id shows up.
                            FbUsername = "tom.albers@iteration35.com",
                        });

                if (!Roles.GetRolesForUser("tom.albers@iteration35.com").Contains("Administrator"))
                    Roles.AddUsersToRoles(new[] { "tom.albers@iteration35.com" }, new[] { "Administrator" });
            }
        }
    }
}


