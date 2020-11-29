using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Loja_Quadrinhos.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }

        [Required]
        [Display(Name = "Nome da Categoria")]
        [MinLength(4)]
        [MaxLength(30)]
        public string CategoriaNome { get; set; }

        [Required]
        [Display(Name = "Descrição detalhada da Descrição")]
        [MinLength(10)]
        [MaxLength(200)]
        public string Descricao { get; set; }

        public virtual List<Produto> Produtos { get; set; }
        public Categoria()
        {

        }
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

        public Categoria(int categoriaId, string categoriaNome, string descricao)
        {
            CategoriaId = categoriaId;
            CategoriaNome = categoriaNome;
            Descricao = descricao;
        }
    }
}
