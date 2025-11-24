using mtg.Api.Models;
using mtg.Data.interfaces;

namespace mtg.Data
{
    public class Usuario : IUsuario
    {
        private readonly MTGContext _context;

        public Usuario(MTGContext context)
        {
            _context = context;
        }

        public Usuarios ? BuscarUsuarioPorEmail(string email)
        {
            return _context.Usuarios.SingleOrDefault(u => u.Email == email);
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