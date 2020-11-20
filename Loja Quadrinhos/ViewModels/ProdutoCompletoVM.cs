using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Loja_Quadrinhos.ViewModels
{
    public class ProdutoCompletoVM
    {
        [Required]
        [Display(Name = "Título do quadrinho")]
        [StringLength(80, MinimumLength = 4)]
        public string Titulo { get; set; }

        [Required]
        [Display(Name = "Autor da obra")]
        [StringLength(60, MinimumLength = 4)]
        public string Autor { get; set; }

        [Required]
        [Display(Name = "Nome da Categoria")]
        [StringLength(60, MinimumLength = 4)]
        public string CategoriaNome { get; private set; }

        [Required]
        [Display(Name = "Descrição detalhada do Quadrinho")]
        [MinLength(20)]
        [MaxLength(200)]
        public string Descricao { get; set; }

        [Required]
        [Display(Name = "Caminho Imagem")]
        [StringLength(200)]
        public string ImagemUrl { get; set; }

        [Required]
        public decimal Preco { get; private set; }
    }
}
