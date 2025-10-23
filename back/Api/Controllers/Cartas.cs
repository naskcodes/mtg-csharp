using Microsoft.AspNetCore.Mvc;

namespace mtg.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Cartas(Data.MTGContext context) : Controller
{
    private readonly Data.MTGContext _context = context;

    [HttpGet("[action]")]
    public IActionResult ListaCartas()
    {
        var retorno = _context.Cartas.ToList();

        return Ok(retorno);
    }
}