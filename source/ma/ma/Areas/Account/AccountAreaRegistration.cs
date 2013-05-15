using System.Web.Mvc;

namespace ma.Areas.Account
{
    public class AccountAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Account";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Account_default",
                "Account/{action}/{id}",
                new { area = "Account", controller = "Account", action = "Login", id = UrlParameter.Optional }
            );
        }
    }
}
