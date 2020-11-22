using Loja_Quadrinhos.Context;
using Loja_Quadrinhos.Models;
using Loja_Quadrinhos.Repositories.Interfaces;
using Loja_Quadrinhos.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Loja_Quadrinhos.Area.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProdutoAdminController : Controller
    {
        private readonly AppDbContext _context;
        private IUnitOfWork UnitOfWork;
        public ImagemService ImagemService { get; private set; }

        public ProdutoAdminController(AppDbContext context, IUnitOfWork unitOfWork, ImagemService imagemService)
        {
            _context = context;
            UnitOfWork = unitOfWork;
            ImagemService = imagemService;
        }

        public  IActionResult Listar()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var produtos = UnitOfWork.ProdutoRepository.Get();
                    if (produtos == null)
                    {
                        ViewData["Url"] = "/ProdutoAdmin";
                        return View("ErroListaVazia", ViewData["Url"]);
                    }
                    return View(produtos);
                }
                catch(Exception ex)
                {
                    return View("Error");
                }


            }
            return View("Error");
        }

        public IActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = UnitOfWork.ProdutoRepository.GetById((int)id);

            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        public IActionResult Cadastrar()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar([Bind("ProdutoId,Titulo,Autor,CategoriaId,Descricao,ImageFile,Preco,QuantidadeVendidos,QuantidadeEmEstoque")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                ImagemService.AddImagens(produto);
                UnitOfWork.ProdutoRepository.Add(produto);
                UnitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome", produto.CategoriaId);
            return View(produto);
        }

        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome", produto.CategoriaId);
            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("ProdutoId,Titulo,Autor,CategoriaId,Descricao,ImagemUrl,Preco,QuantidadeVendidos,QuantidadeEmEstoque")] Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ImagemService.AddImagens(produto);
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.ProdutoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome", produto.CategoriaId);
            return View(produto);
        }

        public async Task<IActionResult> Deletar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            ImagemService.RemoveImagens(produto);
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(e => e.ProdutoId == id);
        }
    }
}
