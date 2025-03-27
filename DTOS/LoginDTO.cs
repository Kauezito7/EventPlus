using System.ComponentModel.DataAnnotations;

namespace Event_plus.DTOS
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "O campo email é obrigatório!!!")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O campo senha é obrigatório!!!")]
        public string? Senha { get; set; }
    }
}
