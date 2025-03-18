using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Event_plus.Domains
{
    [Table("Instituicao")]
    [Index(nameof(CNPJ), IsUnique = true)]
    public class Instituicao
    {
        [Key]
        public Guid IdInstituicao { get; set; }

        [Required(ErrorMessage = "O nome fantasia da instituição é obrigatório."), Column(TypeName = "VARCHAR(255)")]
        public string? NomeFantasia { get; set; }

        [Required(ErrorMessage = "O CNPJ da instituição é obrigatório."), Column(TypeName = "VARCHAR(18)")]
        [StringLength(14)]
        public string? CNPJ { get; set; }

        [Required(ErrorMessage = "O endereço da instituição é obrigatório."), Column(TypeName = "VARCHAR(255)")]
        public string? Endereco { get; set; }

    }
}
