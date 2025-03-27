using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Event_plus.Domains
{
    [Table("Evento")]
    public class Evento
    {
        [Key]
        public Guid IdEvento { get; set; }

        [Required(ErrorMessage = "O nome do evento é obrigatório."), Column(TypeName = "VARCHAR(255)")]
        public string? NomeEvento { get; set; }

        [Required(ErrorMessage = "A data do evento é obrigatória.")]
        public DateTime DataEvento { get; set; }

        public Guid IdTipoEvento { get; set; }

        [ForeignKey("IdTipoEvento")]
        public TipoEvento? TipoEvento { get; set; }

        public Guid IdInstituicao { get; set; }

        [ForeignKey("IdInstituicao")]
        public Instituicao? Instituicao { get; set; }

        public PresencaEventos? PresencasEventos { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "A descricao e obrigatoria!")]
        public string? Descricao { get; set; }
    }
}