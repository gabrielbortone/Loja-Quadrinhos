using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Loja_Quadrinhos.Models.ValueObjects
{
    [Owned]
    public class Name
    {
        [Required]
        [Display(Name = "Informe o seu nome")]
        [StringLength(30, MinimumLength = 3)]
        public string Nome { get; private set; }
        [Required]
        [Display(Name = "Informe o seu sobrenome")]
        [StringLength(30, MinimumLength = 3)]
        public string Sobrenome { get; private set; }
        public Name(string nome, string sobrenome)
        {
            Nome = nome;
            Sobrenome = sobrenome;
        }

    }
}
