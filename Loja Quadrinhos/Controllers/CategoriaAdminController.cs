using Loja_Quadrinhos.Context;
using Loja_Quadrinhos.Models;
using Loja_Quadrinhos.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Loja_Quadrinhos.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoriaAdminController : Controller
    {
        private readonly AppDbContext _context;
        private IUnitOfWork UnitOfWork;
        public CategoriaAdminController(AppDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            UnitOfWork = unitOfWork;
        }

        public IActionResult Listar()
        {
            if (ModelState.IsValid)
            {
                var categorias = UnitOfWork.CategoriaRepository.Get();
                if (categorias == null)
                {
                    ViewData["Url"] = "/CategoriaAdmin";
                    return View("ErroListaVazia", ViewData["Url"]);
                }
                return View(categorias);
            }
            return View("Error");
        }

        public IActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = UnitOfWork.CategoriaRepository.GetById((int)id);

            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar([Bind("CategoriaId, CategoriaNome,Descricao")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.CategoriaRepository.Add(categoria);
                UnitOfWork.Commit();
                return RedirectToAction(nameof(Listar));
            }
            return View(categoria);
        }

        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = UnitOfWork.CategoriaRepository.GetById((int)id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, [Bind("CategoriaId,CategoriaNome,Descricao")] Categoria categoria)
        {
            if (id != categoria.CategoriaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    UnitOfWork.CategoriaRepository.Update(categoria);
                    UnitOfWork.Commit();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaExists(categoria.CategoriaId))
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
            return View(categoria);
        }

        public IActionResult Deletar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = UnitOfWork.CategoriaRepository.GetById((int)id);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var categoria = UnitOfWork.CategoriaRepository.GetById(id);
            UnitOfWork.CategoriaRepository.Delete(categoria);
            UnitOfWork.Commit();
            return RedirectToAction(nameof(Listar));
        }

        private bool CategoriaExists(int id)
        {
            return _context.Categorias.Any(e => e.CategoriaId == id);
        }
    }
}
