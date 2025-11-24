using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mtg.Data;
using mtg.Data.interfaces;

namespace mtg.Api;

[Route("api/[controller]")]
[ApiController]
public class Cartas : Controller
{
    private readonly MTGContext _context;
    private readonly ICarta _carta;

    public Cartas(ICarta carta, MTGContext context)
    {
        _carta = carta;
        _context = context;
    }

    [HttpGet("[action]")]
    public IActionResult ListaCartas()
    {
        var retorno = _context.Cartas.AsNoTracking().Include(p => p.Cores).ToList();

        return Ok(retorno);
    }
    [HttpGet("[action]/{idCarta}")]
    public async Task<IActionResult> AdicionarCarta([FromQuery] int idCarta, [FromBody] string nome)
    {
        var buscarCarta = _carta.BuscarCarta(idCarta);

        if (buscarCarta is not null)
        {
            await _carta.AumentarQuantidadeDeCartas(buscarCarta.Id);

            return Ok("quantidade de Carta Aumentado");
        }

        var novaCarta = new Models.Cartas
        {
            Nome = nome,
        };

        await _carta.AdicionarCarta(novaCarta);

        return Ok(novaCarta.Id);
    }
}