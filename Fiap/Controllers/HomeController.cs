using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {

            ViewData["NomeDoAluno"] = "Thiago";
            ViewBag.NovoNomeDoAluno = "Thiagao";

            ViewBag.ConteudoSinistro = "<script>alert('oi')</script>";


            var pessoa = new Pessoa() { Nome = "Thiago" };
            var homeViewModel = new HomeViewModel() { totalDeNoticias = 123 };
            return View(homeViewModel);
        }


        [HttpGet]
        public IActionResult Redirect(string url)
        {

            if (Url.IsLocalUrl(url))
                return LocalRedirect(url);
            else
                return LocalRedirect("/");

        }

        [HttpGet]
        public IActionResult Teste()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Sobre()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index([FromBody]Pessoa pessoa, [FromHeader]string AppVersion)
        {
            return View();
        }

        public IActionResult Edit(int nomeDoCliente)
        {
            return View();
        }

        public IActionResult Salvar(DadosX pessoa)
        {
            return View();
        }
    }

    public class Pessoa
    {
        public string Nome { get; set; }
    }

    public class DadosX
    {
        public string AppVersion { get; set; }

    }

}
