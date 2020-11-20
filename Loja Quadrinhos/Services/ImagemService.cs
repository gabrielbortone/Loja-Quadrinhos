using Loja_Quadrinhos.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Loja_Quadrinhos.Services
{
    public class ImagemServices
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ImagemServices(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async void AddImagens(Produto produto)
        {
            produto.ImagemUrl = await UploadImage(produto);
        }

        public async void RemoveImagens(Produto produto)
        {
                await DeleteImage(produto);
        }
        private async Task<string> UploadImage(Produto produto)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(produto.ImageFile.FileName);
            string extension = Path.GetExtension(produto.ImageFile.FileName);
            var newFileName = fileName + DateTime.Now.ToString("yyyymmssfff") + extension;
            string path = Path.Combine(wwwRootPath + "/Imagens/", newFileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await produto.ImageFile.CopyToAsync(fileStream);
                return path;
            }

            return "Sem-imagem!!!";

        }

        private async Task DeleteImage(Produto produto)
        {
            if (System.IO.File.Exists(produto.ImagemUrl))
            {
                System.IO.File.Delete(produto.ImagemUrl);
            }
            else
            {
                throw new IOException("Imagem não encontrada!");
            }

        }

    }
}
