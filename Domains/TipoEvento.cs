using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Event_plus.Domains
{
    [Table("TipoEvento")]
    public class TipoEvento
    {
        [Key]
        public Guid IdTipoEvento { get; set; }

        [Required(ErrorMessage = "O título do tipo de evento é obrigatório."), Column(TypeName = "VARCHAR(255)")]
        public string? TituloTipoEvento { get; set; }

    }
}
