using mtg.Api.Models;
using mtg.Data.interfaces;

namespace mtg.Data;

public class Carta : ICarta
{
    private readonly MTGContext _context;

    public Carta(MTGContext context)
    {
        _context = context;
    }

    public async Task<int> AdicionarCarta(Cartas cartas)
    {
        var atributoCarta = _context.Cores.Any(cr => cr.Id == cartas.IdCor);

        if (atributoCarta is false)
        {
            throw new KeyNotFoundException("carta Nao encontrada");
        }

        var novaCarta = new Cartas
        {
            Nome = cartas.Nome,
            IdCor = cartas.IdCor,
            Quantidade = cartas.Quantidade
        };

        _context.Cartas.Add(novaCarta);

        await _context.SaveChangesAsync();

        return cartas.Id;

    }

    public async Task AumentarQuantidadeDeCartas(int cartaId)
    {
        var carta = _context.Cartas.Single(p => p.Id.Equals(cartaId));

        carta.Quantidade += 1;

        await _context.SaveChangesAsync();
    }

    public Task AumentarQuantidadeDeCartaNoPerfil(int cartaId)
    {
        throw new NotImplementedException();
    }

    public Cartas? BuscarCarta(int IdCarta)
    {
        return _context.Cartas.SingleOrDefault(cr => cr.Id.Equals(IdCarta));
    }

    public Task<bool> VerificarExistenciaDaCartaNoPerfil(int cartaId, int usuarioId)
    {
        throw new NotImplementedException();
    }
}

