using EGMTraning.BusinessEngine.Contracts;
using EGMTraning.BusinessEngine.Implementation;
using EGMTraning.Data.DataContracts;
using EGMTraning.Data.Implementation;

namespace EGMTraning.UI.Extentions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IWorkOrderBusinessEngine, WorkOrderBusinessEngine>();
            services.AddScoped<ILanguageBusinessEngine, LanguageBusinessEngine>();
            services.AddScoped<IStringResourceBusinessEngine, StringResourceBusinessEngine>();
            return services;
        }
    }
}
