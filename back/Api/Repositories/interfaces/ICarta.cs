using mtg.Api.Models;

namespace mtg.Api.Repositories.interfaces;

public interface ICarta
{
    Task<int> AdicionarCarta(Cartas cartas);
    Task<bool> VerificarExistenciaDaCartaNoPerfil(int cartaId, int usuarioId);
    Task AumentarQuantidadeDeCartaNoPerfil(int cartaId);
}

