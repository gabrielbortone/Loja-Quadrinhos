using System;
using System.Collections.Generic;

namespace Loja_Quadrinhos.Models
{
    public class Pedido
    {
        public int PedidoId { get; private set; }
        public int UsuarioId { get; private set; }
        public Usuario Cliente { get; private set; }
        public virtual List<PedidoItem> PedidoItens { get; private set; }
        public decimal PedidoTotal { get; private set; }
        public DateTime DataPedido { get; private set; }
        public DateTime? PedidoEntregueEm { get; private set; }

    }
}
