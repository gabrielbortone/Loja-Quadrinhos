using System.ComponentModel.DataAnnotations;

namespace Loja_Quadrinhos.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Usuário")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
