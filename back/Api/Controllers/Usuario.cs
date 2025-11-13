using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mtg.Api.Controllers.Dto;
using mtg.Api.Models;
using mtg.Api.Repositories.interfaces;

namespace mtg.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Usuario : Controller
    {
        private readonly IUsuario _usuario;

        public Usuario(IUsuario usuario)
        {
            _usuario = usuario;
        }

        public IActionResult RegistrarUsuario(RegistrarUsuarioDto dto)
        {

            var verificarEmail = _usuario.VerificaEmail(dto.Email); 
            
            if(verificarEmail is true)
            {
                return Unauthorized("email ja em uso");
            }

            var usuario = new Usuarios
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Senha = dto.Senha,
            };

            var criarUsuario = _usuario.CriarUsuario(usuario);

            return Ok(criarUsuario);    
        }
    }
}
