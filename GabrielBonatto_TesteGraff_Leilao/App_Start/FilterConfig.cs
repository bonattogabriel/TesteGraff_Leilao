using System.Web;
using System.Web.Mvc;

namespace GabrielBonatto_TesteGraff_Leilao
{
  public class FilterConfig
  {
    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
      filters.Add(new HandleErrorAttribute());
    }
  }
}
