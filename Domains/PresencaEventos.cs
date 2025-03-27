using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Event_plus.Domains
{
    [Table("PresencaEventos")]
    public class PresencaEventos
    {
        [Key]
        public Guid IdPresenca { get; set; }

        public Guid IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario? Usuario { get; set; }

        public Guid IdEvento { get; set; }

        [ForeignKey("IdEvento")]
        public Evento? Evento { get; set; }
        public bool Situacao { get; internal set; }
    }
}

