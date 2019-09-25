using Fiap.Core.Models;
using Fiap.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Services
{
    public class NoticiaService : INoticiaService
    {
        public List<Noticia> Load()
        {
            var noticias = new List<Noticia>();
            noticias.Add(new Noticia() { Id = 123, Titulo = "Amazon Prime no Brasil" });
            noticias.Add(new Noticia() { Id = 123, Titulo = "Quinto Andar unicornio" });
            noticias.Add(new Noticia() { Id = 123, Titulo = "Brasil pedeu para o Peru" });
            return noticias;
        }
    }
}
