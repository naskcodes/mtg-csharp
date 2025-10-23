using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace mtg.Api.Models;

public record Carta
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Cor { get; set; } = string.Empty;
    public int Quantidade { get; set; }
}