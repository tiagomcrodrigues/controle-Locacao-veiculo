using Microsoft.AspNetCore.Mvc;

namespace ControleLocacao.Api.Filters
{

    public static class GlobalFilters
    {

        public static void Configure(MvcOptions opt)
        {
            opt.Filters.Add<ValidateModelFilter>();
        }
    }
}
