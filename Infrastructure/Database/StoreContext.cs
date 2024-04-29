using Domain.Aggregations;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infra.Database;

public class StoreContext : DbContext
{
    public StoreContext() {}

    public StoreContext(DbContextOptions<StoreContext> options) : base(options) {}
    
    public virtual DbSet<Accounting> Accounting { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ReleaseEntityTypeConfiguration());
    }
}