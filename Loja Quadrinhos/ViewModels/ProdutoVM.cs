using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Loja_Quadrinhos.ViewModels
{
    public class ProdutoVM
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
        public int CategoriaId { get; set; }

        [Required]
        [Display(Name = "Descrição detalhada do Quadrinho")]
        [MinLength(20)]
        [MaxLength(200)]
        public string Descricao { get; set; }


        [DisplayName("Upload file")]
        public IFormFile ImageFile { get; set; }

        [Required]
        public decimal Preco { get; private set; }


        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int QuantidadeVendidos { get; private set; }


        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int QuantidadeEmEstoque { get; private set; }
    }
}
