using Microsoft.EntityFrameworkCore;
using Outliner.Dal.Templates;

namespace Outliner.Dal.EF;

public class OutlinerDbContext : DbContext
{
    public DbSet<TemplateEntity> Templates { get; set; }

    public OutlinerDbContext(DbContextOptions<OutlinerDbContext> options) : base(options)
    { }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}