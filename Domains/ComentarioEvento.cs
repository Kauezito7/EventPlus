using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Event_plus.Domains
{
    [Table("ComentarioEvento")]
    public class ComentarioEvento
    {
        [Key]
        public Guid IdComentario { get; set; }

        [Required(ErrorMessage = "O campo Exibe é obrigatório.")]
        public bool Exibe { get; set; }

        [Required(ErrorMessage = "A descrição do comentário é obrigatória."), Column(TypeName = "TEXT")]
        public string? Descricao { get; set; }

        [ForeignKey("IdUsuario")]
        public Guid IdUsuario { get; set; }
        public Usuario? Usuario { get; set; }

        [ForeignKey("IdEvento")]
        public Guid IdEvento { get; set; }
        public Evento? Evento { get; set; }

    }
}
 