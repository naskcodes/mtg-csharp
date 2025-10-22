using Microsoft.EntityFrameworkCore;
using mtg.Api.Models;

namespace mtg.Api.Data;

public class MTGContext : DbContext
{
    public MTGContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Carta> Carta { get; set; }
}
