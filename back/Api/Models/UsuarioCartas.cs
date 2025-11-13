using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mtg.Api.Models
{
    [Table("usuarioCartas")]
    public class UsuarioCartas
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("usuarioId")]
        public int UsuarioId { get; set; }
        
        [Column("cartaId")]
        public int CartaId {  get; set; }
        
        [ForeignKey("CartaId")]
        public Cartas? Cartas { get; set; }
        
        [ForeignKey("UsuarioId")]
        public Usuarios? Usuarios { get; set; }
    }
}
