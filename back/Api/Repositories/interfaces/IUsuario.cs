using mtg.Api.Models;

namespace mtg.Api.Repositories.interfaces
{
    public interface IUsuario
    {
       Task<int> CriarUsuario(Usuarios usuario);
       bool VerificaEmail(string email);

    }
}
