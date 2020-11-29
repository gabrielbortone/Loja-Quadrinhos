using System.ComponentModel.DataAnnotations;

namespace Loja_Quadrinhos.ViewModels
{
    public class CategoriaVM
    {
        [Required]
        [Display(Name = "Nome da Categoria")]
        [MinLength(4)]
        [MaxLength(30)]
        public string CategoriaNome { get; private set; }

        [Required]
        [Display(Name = "Descrição detalhada da Descrição")]
        [MinLength(10)]
        [MaxLength(200)]
        public string Descricao { get; private set; }

    }
}
