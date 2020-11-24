using Loja_Quadrinhos.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Loja_Quadrinhos.Components
{
    public class CategoriaMenu : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoriaMenu(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IViewComponentResult Invoke()
        {
            var categorias = _unitOfWork.CategoriaRepository.Get();
            return View(categorias);
        }
    }
}