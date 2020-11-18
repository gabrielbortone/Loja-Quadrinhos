using System;

namespace Loja_Quadrinhos.Models
{
    public class PedidoItem
    { 

        public int PedidoItemId { get; private set; }
        public int PedidoId { get; private set; }
        public Pedido Pedido { get; private set; }
        public int ProdutoId { get; private set; }
        public Produto Produto { get; private set; }
        public int Quantidade { get; private set; }
        public decimal TotalPedidoItem { get; private set; }

        public PedidoItem(int pedidoId, Pedido pedido, int produtoId, Produto produto, int quantidade)
        {
            PedidoId = pedidoId;
            Pedido = pedido;
            ProdutoId = produtoId;
            Produto = produto;
            Quantidade = quantidade;
            if(produto.QuantidadeEmEstoque < Quantidade)
            {
                throw new Exception("Quantidade em estoque menor que o pedido! Por favor reduza a quantidade e tente novamente!");
            }
            else
            {
                TotalPedidoItem = Quantidade * produto.Preco;
            }
        }

    }
}
