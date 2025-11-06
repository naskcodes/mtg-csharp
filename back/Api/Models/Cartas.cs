using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mtg.Api.Models;

[Table("cartas")]
public record Cartas
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("nome")]
    public string Nome { get; set; } = string.Empty;

    [Column("idcor")]
    public int IdCor { get; set; }

    [Column("quantidade")]
    public int Quantidade { get; set; }

    [ForeignKey("IdCor")]
    public Cores? Cores { get; set; }
}