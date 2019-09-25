using Fiap.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Core.Context
{
    public class TurismoContext:DbContext
    {
        public TurismoContext(DbContextOptions<TurismoContext> options) : base(options)
        {

        }

        public DbSet<Destino> Destinos { get; set; }
        public DbSet<Temporada> Temporadas { get; set; }

    }
}
