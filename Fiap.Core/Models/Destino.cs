using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Core.Models
{
    public class Destino
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Pais { get; set; }
        public int Distancia { get; set; }
        public Temporada Temporada { get; set; }
    }

    public class Temporada
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
