namespace Loja_Quadrinhos.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IProdutoRepository ProdutoRepository { get; }
        ICategoriaRepository CategoriaRepository { get; }
        IPedidoRepository PedidoRepository { get; }
        IPedidoItemRepository PedidoItemRepository { get; }
        public void Commit();
    }
}
