using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using mtg.Api.Models;
using Npgsql;

namespace mtg.Data;


public class MTGContextFactory : IDesignTimeDbContextFactory<MTGContext>
{
    public MTGContext CreateDbContext(string[] args)
    {
        var builder = new NpgsqlDataSourceBuilder("Host=localhost;Database=postgres;Username=postgres;Port=2222;Password=postgres");
        builder.EnableDynamicJson();
        var dataSource = builder.Build();

        var optionsBuilder = new DbContextOptionsBuilder<MTGContext>();
        optionsBuilder.UseNpgsql(dataSource);

        return new MTGContext(optionsBuilder.Options);
    }
}

public class MTGContext : DbContext
{
    public MTGContext(DbContextOptions options) : base(options) { }

    public DbSet<Cartas> Cartas { get; set; }
    public DbSet<Cores> Cores { get; set; }
    public DbSet<Usuarios> Usuarios { get; set; }
    public DbSet<UsuarioCartas> UsuariosCartas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {       
       modelBuilder.Entity<Usuarios>()
            .HasIndex(u=> u.Email)
            .IsUnique();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .EnableSensitiveDataLogging();

    }
}