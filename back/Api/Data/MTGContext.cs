using Microsoft.EntityFrameworkCore;
using mtg.Api.Models;

namespace mtg.Api.Data;

public class MTGContext : DbContext
{
    public MTGContext(DbContextOptions options) : base(options) { }


    public DbSet<Carta> Cartas { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carta>().HasKey(p => p.Id);
    }
}