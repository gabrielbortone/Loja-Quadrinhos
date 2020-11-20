using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Loja_Quadrinhos.Models.ValueObjects
{
    [Owned]
    public class Endereco
    {
        [Required]
        [Display(Name = "Informe o seu logradouro")]
        [StringLength(30, MinimumLength = 3)]
        public string Logradouro { get; set; }

        [Required]
        public int Numero { get; set; }

        [Required]
        [Display(Name = "Informe o CEP:")]
        [StringLength(8, MinimumLength = 8)]
        public string CEP { get; set; }

        [Required]
        [Display(Name = "Informe o bairro:")]
        [StringLength(30, MinimumLength = 4)]
        public string Bairro { get; set; }

        [Required]
        [Display(Name = "Informe a cidade:")]
        [StringLength(35, MinimumLength = 4)]
        public string Cidade { get; set; }

        [Required]
        [Display(Name = "Informe o Estado:")]
        [StringLength(35, MinimumLength = 4)]
        public string Estado { get; set; }

        public Endereco(string logradouro, int numero, string cEP, string bairro, string cidade, string estado)
        {
            Logradouro = logradouro;
            Numero = numero;
            CEP = cEP;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
        }
    }
}
