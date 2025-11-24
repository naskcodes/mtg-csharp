using mtg.Api.Models;

namespace mtg.Data.interfaces;

public interface IUsuario
{
    Task<int> CriarUsuario(Usuarios usuario);
    bool VerificaEmail(string email);
    Usuarios ? BuscarUsuarioPorEmail(string email);
}

