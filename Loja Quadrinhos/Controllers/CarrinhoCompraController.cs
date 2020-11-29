using Loja_Quadrinhos.Models;
using Loja_Quadrinhos.Services;
using Loja_Quadrinhos.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Loja_Quadrinhos.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly CarrinhoCompraService _carrrinhoCompraService;
        private readonly UserManager<Usuario> _userManager;

        public CarrinhoCompraController(CarrinhoCompraService carrinhoCompraService, UserManager<Usuario> userManager)
        {
            _carrrinhoCompraService = carrinhoCompraService;
            _userManager = userManager;
        }

        
        public IActionResult ListarItens()
        {

            var carrinhoCompraVM = new CarrinhoCompraVM
            {
                CarrinhoCompraItens = _carrrinhoCompraService.GetItensDoCarrinho(),
                QuantidadeItens = _carrrinhoCompraService.GetCarrinhoCompraQuantidade(),
                Total = _carrrinhoCompraService.GetCarrinhoCompraTotal()
            };

            return View(carrinhoCompraVM);
        }

        [Authorize(Roles = "Member")]
        public async Task FinalizaPedido()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            _carrrinhoCompraService.FinalizaPedido(user);
        }

    }
}
