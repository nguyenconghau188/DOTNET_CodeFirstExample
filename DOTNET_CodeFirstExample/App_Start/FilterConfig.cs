using System.Web;
using System.Web.Mvc;

namespace DOTNET_CodeFirstExample
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
