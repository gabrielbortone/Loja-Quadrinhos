
using Loja_Quadrinhos.Services;
using Loja_Quadrinhos.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Loja_Quadrinhos.Components
{
    public class CarrinhoCompraResumo : ViewComponent
    {
        private readonly CarrinhoCompraService _carrinhoCompraService;

        public CarrinhoCompraResumo(CarrinhoCompraService carrinhoCompraService)
        {
            _carrinhoCompraService = carrinhoCompraService;
        }

        public IViewComponentResult Invoke()
        {
            var carrinhoCompraVM = new CarrinhoCompraVM
            {
                CarrinhoCompraItens = _carrinhoCompraService.GetItensDoCarrinho(),
                QuantidadeItens = _carrinhoCompraService.GetCarrinhoCompraQuantidade(),
                Total = _carrinhoCompraService.GetCarrinhoCompraTotal()
            };



            return View(carrinhoCompraVM);
        }
    }
}
