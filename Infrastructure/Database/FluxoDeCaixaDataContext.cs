using Domain.Aggregations;
using Microsoft.EntityFrameworkCore;

namespace Infra.Database;

public class FluxoDeCaixaDataContext : DbContext
{
    public FluxoDeCaixaDataContext() {}

    public FluxoDeCaixaDataContext(DbContextOptions<FluxoDeCaixaDataContext> options) : base(options) {}
    
    public DbSet<BookEntry> BookEntries { get; set; }
}