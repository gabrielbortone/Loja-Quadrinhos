namespace Loja_Quadrinhos.Models
{
    public class Produto
    {
        public int ProdutoId { get; }
        public string Titulo { get; }
        public string Autor { get;  }
        public string Categoria { get; }
        public string Descricao { get;  }
        public decimal Preco { get; set; }
        public int QuantidadeEmEstoque { get; set; }

    }
}
