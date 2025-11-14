using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using mtg.Api.Data;
using mtg.Api.Models;
using mtg.Api.Repositories;

namespace Mtg.Test.Repositories;

public class UsuarioTests
{
    private readonly DbContextOptions<MTGContext> _options;
    public UsuarioTests()
    {
        _options = new DbContextOptionsBuilder<MTGContext>()
             .UseInMemoryDatabase(databaseName: "database")
             .Options;
    }
    [Fact]
    public async Task DeveRetornarOTipoDoIdDeRegistro()
    {
        using var context = new MTGContext(_options);

        var repository = new Usuario(context);

        var usuario = new Usuarios
        {
            Nome = "Teste",
            Email = "teste@mail.com",
            Senha = "senha"
        };

        var criarUsuario = await repository.CriarUsuario(usuario);

        criarUsuario.Should().NotBe(null);

        criarUsuario.Should().BeOfType(typeof(int));
    }
}
