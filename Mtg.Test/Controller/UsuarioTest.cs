using FluentAssertions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Moq;
using mtg.Api.Controllers;
using mtg.Api.Controllers.Dto;
using mtg.Api.Models;
using mtg.Api.Repositories.interfaces;

namespace Mtg.Test.Controller;

public class UsuarioTest
{
    private readonly Mock<IUsuario> mockRepository;
    public UsuarioTest()
    {
        mockRepository = new Mock<IUsuario>();
    }

    [Fact]
    public async Task DeveRetornarUnauthorized()
    {
        var usuarioDto = new RegistrarUsuarioDto
        {
            Nome = "teste",
            Email = "teste",
            Senha = "teste",
        };

        mockRepository.Setup(p => p.VerificaEmail(usuarioDto.Email)).Returns(true);
        var usuarioMock = new Usuario(mockRepository.Object);

        var semAuthorizacao = await usuarioMock.RegistrarUsuario(usuarioDto);

        semAuthorizacao.Should().BeOfType<UnauthorizedObjectResult>();

        var resultado = semAuthorizacao as UnauthorizedObjectResult;

        resultado.Should().NotBeNull();

        resultado.Value.Should().Be("email ja em uso");
    }
    [Fact]
    public void DeveRetornarErroDeEmailEncontrado()
    {
        var email = "error@mail.com";

        mockRepository.Setup(p => p.BuscarUsuarioPorEmail(email)).Returns(null as Usuarios);

        var usuarioMock = new Usuario(mockRepository.Object);

        var erro = () => usuarioMock.UsuarioEntrar(email, "senha");

        erro.Should().Throw<KeyNotFoundException>();    
    }

    [Fact]
    public void DeveRetornarOTokenEmailNome()
    {
        var usuario = new Usuarios
        {
            Nome = "correto",
            Senha = BCrypt.Net.BCrypt.HashPassword("senha"),
            Email = "correto@mail.com"
        };

        mockRepository.Setup(p => p.BuscarUsuarioPorEmail(usuario.Email)).Returns(usuario);

        var controller = new Usuario(mockRepository.Object);

        var resultado = controller.UsuarioEntrar(usuario.Email, "senha");

        var ok = resultado.Should().BeOfType<OkObjectResult>().Which;    

        ok.Should().NotBeNull();

        ok.Value.Should().BeOfType<UsuarioLogadoDto>();
    }

    [Fact]
    public async Task DeveRegistrarComSucesso()
    {
        var usuarioDto = new RegistrarUsuarioDto
        {
            Nome = "teste",
            Email = "teste",
            Senha = "teste",
        };

        mockRepository.Setup(p => p.VerificaEmail(usuarioDto.Email)).Returns(false);

        var usuarioMock = new Usuario(mockRepository.Object);

        var semAuthorizacao = await usuarioMock.RegistrarUsuario(usuarioDto);

        semAuthorizacao.Should().BeOfType<OkObjectResult>();

        var resultado = semAuthorizacao as OkObjectResult;

        resultado.Should().NotBeNull();

        resultado.Value.Should().BeOfType<int>();
    }
}

