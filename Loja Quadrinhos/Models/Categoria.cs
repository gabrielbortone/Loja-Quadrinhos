using System.Collections.Generic;

namespace Loja_Quadrinhos.Models
{
    public class Categoria
    {
        public int CategoriaId { get; private set; }
        public string CategoriaNome { get; private set; }
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
