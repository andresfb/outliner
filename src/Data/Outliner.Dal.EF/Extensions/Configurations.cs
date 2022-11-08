using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Outliner.Dal.Templates;

namespace Outliner.Dal.EF.Extensions;

public static class Configurations
{
    public static void AddDalEfCore(this IServiceCollection services, string configurationString)
    {
        services.AddDbContext<OutlinerDbContext>(options => options.UseSqlServer(configurationString));
        services.AddTransient<ITemplateDal, ITemplateDal>();
    }
}