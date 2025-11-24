
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using mtg.Api.Models;
using mtg.Api.Repositories;
using mtg.Data;

namespace Mtg.Test.Repositories;

public class CartasTestes
{
    private readonly DbContextOptions<MTGContext> _options;

    public CartasTestes()
    {
        _options = new DbContextOptionsBuilder<MTGContext>()
             .UseInMemoryDatabase(databaseName: "database")
             .Options;
    }

    [Fact]
    public async Task DeveRetornarErroDeNaoExistirCorNoBanco()
    {
        using var context = new MTGContext(_options);

        var repositorioDeCartas = new Carta(context);

        var novaCarta = new Cartas
        {
            Nome = "error",
            IdCor = 1,
            Quantidade = 1
        };
        Func<Task> error = async () => await repositorioDeCartas.AdicionarCarta(novaCarta);

        await error.Should().ThrowAsync<KeyNotFoundException>();
    }

    [Fact]
    public async Task DeveAumentarQuantidadeDeCartas()
    {
        using var context = new MTGContext(_options);

        var cores = new Cores
        {
            Nome = "Simic",
            CoresCarta = new List<string> { "verde", "azul" },
        };

        context.Cores.Add(cores);

        await context.SaveChangesAsync();        
        
        var novaCarta = new Cartas
        {
            Nome = "carta sucesso",
            IdCor = cores.Id,
            Quantidade = 1
        };

        context.Cartas.Add(novaCarta);

        await context.SaveChangesAsync();

        var cartaParaAumentar = context.Cartas.Single(p => p.Id.Equals(novaCarta.Id));

        cartaParaAumentar.Quantidade += 1;

        await context.SaveChangesAsync();

        cartaParaAumentar.Should().NotBeNull();

        cartaParaAumentar.Quantidade.Should().Be(2);
    }

    [Fact]
    public async Task DeveRetornarSucessoEAdicionarAoBanco()
    {
        using var context = new MTGContext(_options);

        var cores = new Cores
        {
            Nome = "Simic",
            CoresCarta = new List<string> { "verde", "azul" },
        };

        context.Cores.Add(cores);

        await context.SaveChangesAsync();

        var repositorioDeCartas = new Carta(context);

        var novaCarta = new Cartas
        {
            Nome = "carta sucesso",
            IdCor = cores.Id,
            Quantidade = 1
        };

        var resultado = await repositorioDeCartas.AdicionarCarta(novaCarta);

        resultado.Should().NotBe(null);

        resultado.Should().BeOfType(typeof(int));

        resultado.Should().Be(novaCarta.Id);
    }
}

