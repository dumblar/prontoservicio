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
        public DbSet<TblSolicitudesCaracteristicas> TblSolicitudesCaracteristicas { get; set; }
        public DbSet<TblTerceros> TblTerceros { get; set; }
        public DbSet<TblSolicitudes> TblSolicitudes { get; set; }
        public DbSet<SpSolicitudesConsultar> SpSolicitudesConsultar { get; set; }
        public DbSet<TblMoviles> TblMoviles { get; set; }
        protected override void OnModelCreating(ModelBuilder model)
        {
            new TblUsuarios.Mapeo(model.Entity<TblUsuarios>());
            new TblSolicitudesCaracteristicas.Mapeo(model.Entity<TblSolicitudesCaracteristicas>());
            new TblTerceros.Mapeo(model.Entity<TblTerceros>());
            new TblSolicitudes.Mapeo(model.Entity<TblSolicitudes>());
            new TblMoviles.Mapeo(model.Entity<TblMoviles>());
            new SpSolicitudesConsultar.Mapeo(model.Entity<SpSolicitudesConsultar>());

        }
    }
}
