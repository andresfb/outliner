using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Outliner.Dal.Templates;

namespace Outliner.Dal.EF.Extensions;

public static class Configurations
{
    public static void AddDalEfCore(this IServiceCollection services, IConfiguration config)
    {
        var conString = config.GetConnectionString("outliner");
        services.AddDbContext<OutlinerDbContext>(options => options.UseSqlServer(conString));
        services.AddTransient<ITemplateDal, ITemplateDal>();
    }
}