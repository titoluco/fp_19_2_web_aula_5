using System;
using System.ComponentModel.DataAnnotations;

namespace Fiap.Core.Models
{
    [Serializable]
    public class Noticia
    {
        public int Id { get;  set; }

        [Required]
        public string Titulo { get;  set; }
        public string Imagem { get; set; }
        public string Link{ get; set; }
    }
}