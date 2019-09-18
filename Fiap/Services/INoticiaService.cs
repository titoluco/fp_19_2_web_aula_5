using System.Collections.Generic;
using Fiap.Models;
using Fiap.ViewComponents;

namespace Fiap.Services
{
    public interface INoticiaService
    {
        List<Noticia> Load();
    }
}