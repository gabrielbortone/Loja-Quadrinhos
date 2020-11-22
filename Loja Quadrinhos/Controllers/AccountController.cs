using Loja_Quadrinhos.Models;
using Loja_Quadrinhos.Models.ValueObjects;
using Loja_Quadrinhos.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Loja_Quadrinhos.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly string _senhaMestra;
        public AccountController(UserManager<Usuario> userManager, SignInManager<Usuario> signManager)
        {
            _userManager = userManager;
            _signInManager = signManager;
            _senhaMestra = "GB_KubuntuLTS";
        }

        //implementar login, registro e logout
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginVM()
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
                return View(loginVM);

            var user = await _userManager.FindByNameAsync(loginVM.UserName);

            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(loginVM.ReturnUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    return Redirect(loginVM.ReturnUrl);
                }
            }

            ModelState.AddModelError("", "Usuário/Senha inválidos ou não localizados!!");
            return View(loginVM);
        }

        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registrar(RegisterUserVM registroVM)
        {
            if (ModelState.IsValid)
            {
                var user = new Usuario(new Name(registroVM.Nome,registroVM.Sobrenome), registroVM.Username,
                    registroVM.Email,registroVM.NumeroTelefone, registroVM.CPF,
                    new Endereco(registroVM.Logradouro, registroVM.Numero,registroVM.CEP, registroVM.Bairro, registroVM.Cidade, registroVM.Estado));
                var result = await _userManager.CreateAsync(user, registroVM.Password);

                if (result.Succeeded)
                {
                    if(registroVM.PasswordMestra == _senhaMestra)
                    {
                        await _userManager.AddToRoleAsync(user, "Admin");
                        await _signInManager.SignInAsync(user, isPersistent: false);
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, "Member");
                        await _signInManager.SignInAsync(user, isPersistent: false);
                    }
                    return RedirectToAction("LoggedIn", "Account");
                }
            }
            return View(registroVM);
        }

        public ViewResult LoggedIn() => View();

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
