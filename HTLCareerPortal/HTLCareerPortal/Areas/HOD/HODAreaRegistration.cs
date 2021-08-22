using System.Web.Mvc;

namespace HTLCareerPortal.Areas.HOD
{
    public class HODAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "HOD";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "HOD_default",
                "HOD/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                 new[] { "HTLCareerPortal.Areas.HOD.Controllers" }
            );
        }
    }
}