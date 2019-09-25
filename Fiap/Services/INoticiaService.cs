using System.Collections.Generic;
using Fiap.Core.Models;
using Fiap.ViewComponents;

namespace Fiap.Services
{
    public interface INoticiaService
    {
        List<Noticia> Load();
    }
}