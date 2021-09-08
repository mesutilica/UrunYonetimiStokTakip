using System.Web;
using System.Web.Mvc;

namespace UrunYonetimiStokTakip.MvcUI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
