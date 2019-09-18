using System.ComponentModel.DataAnnotations;

namespace Fiap.Models
{
    public class Noticia
    {
        public int Id { get; internal set; }

        [Required]
        public string Titulo { get; internal set; }
    }
}