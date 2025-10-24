using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mtg.Api.Models;

[Table("cores")]
public record Cores
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("nome")]
    public string Nome { get; set; } = string.Empty;

    [Column("cores", TypeName = "jsonb")]
    public List<string> CoresCarta { get; set; } = new List<string>();
    public string ListaNomes => string.Join(", ", CoresCarta);

    [InverseProperty("Cores")]
    public List<Cartas>? Cartas { get; set; }
}