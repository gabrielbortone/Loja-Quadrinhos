using System;

namespace Loja_Quadrinhos.Models
{
    public class Produto
    {
        public int ProdutoId { get; private set; }
        public string Titulo { get; private set; }
        public string Autor { get; private set; }
        public int CategoriaId { get; private set; }
        public virtual Categoria Categoria { get; private set; }
        public string Descricao { get; private set; }
        public string ImagemUrl { get; private set; }
        public decimal Preco { get; private set; }
        public int QuantidadeEmEstoque { get; private set; }

        public void Comprar(int quantidade)
        {
            if(quantidade > QuantidadeEmEstoque)
            {
                throw new Exception("Quantidade maior que o estoque!");
            }
            this.QuantidadeEmEstoque -= quantidade;
        }

    }
}
