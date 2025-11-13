using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mtg.Api.Models;


[Table("usuarios")]
public class Usuarios
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("nome")]
    public string Nome { get; set; } = string.Empty;
    
    [Column("email")]
    public string Email { get; set; } = string.Empty;

    [Column("senha")]
    public string Senha { get; set; } = string.Empty;
    
    public List<UsuarioCartas>? UsuarioCarta { get; set; }
}

