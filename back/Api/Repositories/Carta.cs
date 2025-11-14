using Microsoft.AspNetCore.Http.HttpResults;
using mtg.Api.Data;
using mtg.Api.Models;
using mtg.Api.Repositories.interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace mtg.Api.Repositories;

public class Carta : ICarta
{
    private readonly Api.Data.MTGContext _context;

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
            Nome = cartas.Nome ,
            IdCor = cartas.IdCor,
            Quantidade = cartas.Quantidade
        };

        _context.Cartas.Add(novaCarta);

        await _context.SaveChangesAsync();

        return cartas.Id;

    }

    public Task AumentarQuantidadeDeCartaNoPerfil(int cartaId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> VerificarExistenciaDaCartaNoPerfil(int cartaId, int usuarioId)
    {
        throw new NotImplementedException();
    }
}

