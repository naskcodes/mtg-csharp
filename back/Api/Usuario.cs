using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using mtg.Api.Controllers.Dto;
using mtg.Api.Helpers;
using mtg.Api.Models;
using mtg.Data.interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace mtg.Api;

[Route("api/[controller]")]
[ApiController]
public class Usuario : Controller
{
    private readonly IUsuario _usuario;

    public Usuario(IUsuario usuario)
    {
        _usuario = usuario;
    }

    [HttpPost("[action]")]
    public async Task<ActionResult> RegistrarUsuario(RegistrarUsuarioDto dto)
    {

        var verificarEmail = _usuario.VerificaEmail(dto.Email);

        if (verificarEmail is true)
        {
            return Unauthorized("email ja em uso");
        }

        var usuario = new Usuarios
        {
            Nome = dto.Nome,
            Email = dto.Email,
            Senha = BCrypt.Net.BCrypt.HashPassword(dto.Senha),
        };

        var criarUsuario = await _usuario.CriarUsuario(usuario);

        return Ok(criarUsuario);
    }

    [HttpPost("[action]")]
    public ActionResult UsuarioEntrar(string email, string senha)
    {
        var verificarEmail = _usuario.BuscarUsuarioPorEmail(email);

        if (verificarEmail is null || BCrypt.Net.BCrypt.Verify(senha, verificarEmail.Senha) is false)
        {
            throw new KeyNotFoundException("senha ou email incorretos");
        }

        return Ok(new UsuarioLogadoDto(verificarEmail.Nome, email, GenerateAuthToken(verificarEmail)));
    }

    private static ClaimsIdentity GenerateClaims(Usuarios usuario)
    {
        var claims = new ClaimsIdentity();

        claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()));

        claims.AddClaim(new Claim(ClaimTypes.Email, usuario.Email));

        return claims;
    }

    private string GenerateAuthToken(Usuarios usuario)
    {
        var handler = new JwtSecurityTokenHandler();

        var key = Encoding.ASCII.GetBytes(AuthSetting.PrivateKey);

        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature
        );

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            SigningCredentials = credentials,
            Expires = DateTime.UtcNow.AddHours(1),
            Subject = GenerateClaims(usuario)
        };

        var token = handler.CreateToken(tokenDescriptor);

        return handler.WriteToken(token);
    }
}

