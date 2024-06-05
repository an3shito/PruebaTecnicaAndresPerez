using System.ComponentModel.DataAnnotations;

namespace Login.Models
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Usuario Requerido.")]
        public required string Username { get; set; }

        [Required(ErrorMessage = "Contraseña Requerida")]
        public required string Password { get; set; }
    }
}
