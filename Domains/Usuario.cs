using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Event_plus.Domains
{
    [Table("Usuario")]
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório."), Column(TypeName = "VARCHAR(255)")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório."), Column(TypeName = "VARCHAR(255)")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
        public string? Email { get; set; }
         
        [Required(ErrorMessage = "A senha é obrigatória."), Column(TypeName = "VARCHAR(255)")]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "A senha deve conter entre 5 e 30 caracteres.")]
        public string? Senha { get; set; }

        [ForeignKey("IdTipoUsuario")]
        public Guid IdTipoUsuario { get; set; }
        public TipoUsuario? TipoUsuario { get; set; }

    }
}
