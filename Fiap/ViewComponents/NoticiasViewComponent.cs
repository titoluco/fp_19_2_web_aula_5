using Fiap.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.ViewComponents
{
    public class NoticiasViewComponent :ViewComponent
    {
        private INoticiaService _noticiaService;

        public NoticiasViewComponent(INoticiaService noticiaService)
        {
            _noticiaService = noticiaService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int quantidade, bool noticiasurgentes)
        {
            string view = "noticias";
            if (noticiasurgentes)
            {
                view = "noticiasUrgentes";
            }

            return View(view, _noticiaService.Load());
        }

        
    }
}
