using Microsoft.EntityFrameworkCore;
using mtg.Api.Models;

namespace mtg.Api.Data;

public class MTGContext : DbContext
{
    public MTGContext(DbContextOptions options) : base(options) { }


    public DbSet<Cartas> Cartas { get; set; }
    public DbSet<Cores> Cores { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .EnableSensitiveDataLogging();

    }
}