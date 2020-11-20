using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Loja_Quadrinhos.Models
{
    public class Categoria
    {
        public int CategoriaId { get; private set; }

        [Required]
        [Display(Name = "Nome da Categoria")]
        [MinLength(4)]
        [MaxLength(30)]
        public string CategoriaNome { get; private set; }

        [Required]
        [Display(Name = "Descrição detalhada do Quadrinho")]
        [MinLength(20)]
        [MaxLength(200)]
        public string Descricao { get; private set; }
        public virtual List<Produto> Produtos { get; set; }

        public Categoria(string categoriaNome, string descricao)
        {
            CategoriaNome = categoriaNome;
            Descricao = descricao;
        }
        public Categoria(int categoriaId, string categoriaNome, string descricao, List<Produto> produtos)
        {
            CategoriaId = categoriaId;
            CategoriaNome = categoriaNome;
            Descricao = descricao;
            Produtos = produtos;
        }
    }
}
