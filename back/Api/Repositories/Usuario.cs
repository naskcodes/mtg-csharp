using mtg.Api.Data;
using mtg.Api.Models;

namespace mtg.Api.Repositories
{
    public class Usuario : Repositories.interfaces.IUsuario
    {
        private readonly Api.Data.MTGContext _context;

        public Usuario(MTGContext context)
        {
            _context = context;
        }

        public async Task<int> CriarUsuario(Usuarios usuario)
        {

            var CriarUsuario = new Usuarios
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = usuario.Senha,       
            };  

            _context.Usuarios.Add(CriarUsuario); 
            
            await _context.SaveChangesAsync();

            return usuario.Id;
        }

        public bool VerificaEmail(string email)
        {
            return _context.Usuarios.Any(p=> p.Email == email);
        }
    }
}
