using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiap.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Controllers
{
    public class NoticiasController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index([FromBody]Noticia noticia)
        {
            return View();
        }
    }
}