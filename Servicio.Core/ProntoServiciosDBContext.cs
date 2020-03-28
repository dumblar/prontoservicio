using Microsoft.EntityFrameworkCore;
using Servicio.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicio.Core
{
    public class ProntoServiciosDBContext : DbContext
    {
        public ProntoServiciosDBContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<TblUsuarios> TblUsuarios { get; set; }
        protected override void OnModelCreating(ModelBuilder model)
        {
            new TblUsuarios.Mapeo(model.Entity<TblUsuarios>());

        }
    }
}
