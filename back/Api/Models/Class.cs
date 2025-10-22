namespace mtg.Api.Models;

public record Carta
{
    public int IdCarta { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Cor { get; set; } = string.Empty;
    public int Quantidade { get; set; }
}