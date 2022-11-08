using Microsoft.EntityFrameworkCore;
using Outliner.Dal.Templates;

namespace Outliner.Dal.EF;

public class OutlinerDbContext : DbContext
{
    public DbSet<TemplateEntity> Templates { get; set; }

#pragma warning disable CS8618
    public OutlinerDbContext(DbContextOptions<OutlinerDbContext> options) : base(options)
#pragma warning restore CS8618
    { }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}