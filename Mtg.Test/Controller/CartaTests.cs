using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using mtg.Api.Models;
using mtg.Data;
using mtg.Data.interfaces;
using CartaController = mtg.Api.Controllers;

namespace Mtg.Test.Controller;

public class CartaTests
{
    private readonly Mock<ICarta> mockCarta;
    private readonly DbContextOptions<MTGContext> _options;

    public CartaTests()
    {
        mockCarta = new Mock<ICarta>();
        _options = new DbContextOptionsBuilder<MTGContext>()
             .UseInMemoryDatabase(databaseName: "database")
             .Options;
    }
    [Fact]
    public async Task DeveAumentarQuantidadeDeCartas()
    {
        using var context = new MTGContext(_options);

        var carta = new Cartas
        {
            Id= 1,
            Nome = "carta qualquer",
            IdCor = 1,       
        };

         mockCarta.Setup(p=> p.BuscarCarta(carta.Id)).Returns(carta);

        var cartaController = new CartaController.Cartas(mockCarta.Object, context);

        var novaCarta = await cartaController.AdicionarCarta(carta.Id, carta.Nome);
        
        novaCarta.Should().BeOfType<OkObjectResult>();

        var resultado = novaCarta as OkObjectResult;

        resultado.Value.Should().Be("quantidade de Carta Aumentado");
    }
    [Fact]

    public async Task DeveAdicionarUmaNovaCartaAoBanco()
    {
        using var context = new MTGContext(_options);

        var carta = new Cartas
        {
            Nome = "carta qualquer",
            IdCor = 1,
        };

        mockCarta.Setup(p => p.BuscarCarta(carta.Id)).Returns(null as Cartas);

        var cartaController = new CartaController.Cartas(mockCarta.Object, context);

        var novaCarta = await cartaController.AdicionarCarta(carta.Id, carta.Nome);

        novaCarta.Should().BeOfType<OkObjectResult>();

        var resultado = novaCarta as OkObjectResult;

        resultado.Value.Should().Be(0);
    }

}

