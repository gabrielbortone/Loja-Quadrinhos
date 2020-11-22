using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loja_Quadrinhos.Repositories;
using Loja_Quadrinhos.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Loja_Quadrinhos.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProdutoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Listar()
        {
            var produtos = _unitOfWork.ProdutoRepository.Get().OrderBy(produto => produto.QuantidadeVendidos);
            if (produtos != null)
            {
                return View(produtos);
            }
            return View("Error");
        }

        public IActionResult ListarProdutoPorCategoria(int categoriaId)
        {
            var categoria = _unitOfWork.CategoriaRepository.GetById(categoriaId);
            var produtos = _unitOfWork.ProdutoRepository.GetByCategoria(categoria);
            if (produtos != null)
            {
                return View(produtos);
            }
            return View("Error");
        }
    }
}
