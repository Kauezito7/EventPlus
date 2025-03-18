using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Event_plus.Domains
{
    [Table("TipoUsuario")]
    public class TipoUsuario
    {
        [Key]
        public int IdTipoUsuario { get; set; }

        [Required(ErrorMessage = "O título do tipo de usuário é obrigatório."), Column(TypeName = "VARCHAR(255)")]
        public string? TituloTipoUsuario { get; set; }

    }
}
