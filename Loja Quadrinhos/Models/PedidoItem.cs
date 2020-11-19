using System;

namespace Loja_Quadrinhos.Models
{
    public class PedidoItem
    { 
        public int PedidoItemId { get; private set; }
        public int PedidoId { get; private set; }
        public virtual Pedido Pedido { get; private set; }
        public int ProdutoId { get; private set; }
        public virtual Produto Produto { get; private set; }
        public int Quantidade { get; private set; }
        public decimal TotalPedidoItem { get; private set; }

    }
}
