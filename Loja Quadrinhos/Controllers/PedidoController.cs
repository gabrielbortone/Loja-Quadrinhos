using Loja_Quadrinhos.Models;
using Loja_Quadrinhos.Repositories;
using Loja_Quadrinhos.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Loja_Quadrinhos.Controllers
{
    [Authorize]
    public class PedidoController : Controller
    {
        private IUnitOfWork UnitOfWork;
        private readonly UserManager<Usuario> _userManager;

        public PedidoController(UnitOfWork unitOfWork, UserManager<Usuario> userManager)
        {
            UnitOfWork = unitOfWork;
            _userManager = userManager;
        }
        public async Task<IActionResult> Listar()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var pedidos = UnitOfWork.PedidoRepository.GetPedidosByUser(user);
            return View(pedidos);
        }

        public IActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = UnitOfWork.PedidoRepository.GetById((int)id);

            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var pedido = UnitOfWork.PedidoRepository.GetById((int)id);
            if (pedido == null)
            {
                return NotFound();
            }
            return View(pedido);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, [Bind("PedidoId,UsuarioId,PedidoTotal,DataPedido,PedidoEntregueEm")] Pedido pedido)
        {
            if (id != pedido.PedidoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    UnitOfWork.PedidoRepository.Update(pedido);
                    UnitOfWork.Commit();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.PedidoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Listar));
            }
            return View(pedido);
        }

        public IActionResult Deletar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = UnitOfWork.PedidoRepository.GetById((int)id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var pedido = UnitOfWork.PedidoRepository.GetById((int)id);
            UnitOfWork.PedidoRepository.Delete(pedido);
            UnitOfWork.Commit();
            return RedirectToAction(nameof(Listar));
        }

        private bool PedidoExists(int id)
        {
            return UnitOfWork.PedidoRepository.GetById(id) != null;
        }
    }
}
