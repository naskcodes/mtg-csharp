using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mtg.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Cartas(Data.MTGContext context) : Controller
{
    private readonly Data.MTGContext _context = context;

    [HttpGet("[action]")]
    public IActionResult ListaCartas()
    {
        var retorno = _context.Cartas.AsNoTracking().Include(p => p.Cores).ToList();

        return Ok(retorno);
    }
}