﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Loja_Quadrinhos.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
