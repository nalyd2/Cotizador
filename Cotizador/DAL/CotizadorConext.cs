using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Cotizador.Models;
namespace Cotizador.DAL
{
    public class CotizadorConext : DbContext
    {
        public CotizadorConext() :base("name=CotizadorConext")
        {

        }
        public DbSet<Componente> Componentes { get; set; }
        public DbSet<Costos> Costos { get; set; }
        public DbSet<Cotizacion> Cotizacions { get; set; }
        public DbSet<CotizacionDet> CotizacionDets { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Sistema> Sistemas { get; set; }
        public DbSet<TipoCosto> TipoCostos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Marca>().HasKey(m => m.IDMarca);
            modelBuilder.Entity<Marca>().HasIndex(m => m.IDMarca);

            modelBuilder.Entity<Modelo>().HasKey(m => m.IDModelo);
            modelBuilder.Entity<Modelo>().HasIndex(m => m.IDModelo);
            modelBuilder.Entity<Modelo>().HasRequired<Marca>(m => m.Marca)
                .WithMany(r => r.Modelos).HasForeignKey(m => m.IDMarca);

            modelBuilder.Entity<Sistema>().HasKey(s => s.IDSistema);
            modelBuilder.Entity<Sistema>().HasIndex(s => s.IDSistema);
            modelBuilder.Entity<Sistema>().HasRequired(s => s.Modelo)
                .WithMany(m => m.Sistemas).HasForeignKey(s => s.IDModelo);

            modelBuilder.Entity<Producto>().HasKey(p => p.IDProducto);
            //modelBuilder.Entity<Producto>().HasIndex(p => p.IDProducto);
            //modelBuilder.Entity<Producto>().HasRequired(p => p.Sistema)
            //    .WithMany(s => s.Productos).HasForeignKey(p => p.IDProducto);

            modelBuilder.Entity<Componente>().HasKey(c => new { c.IDComponente });
            modelBuilder.Entity<Componente>().HasIndex(c => c.IDComponente);
            //modelBuilder.Entity<Componente>().HasRequired(s => s.Sistema)
            //    .WithMany(c => c.Componentes).HasForeignKey<int>(s => s.IDSistema);

            modelBuilder.Entity<Cotizacion>().HasKey(c => c.IDCotizacion);
            modelBuilder.Entity<Cotizacion>().HasIndex(c => c.IDCotizacion);
            //modelBuilder.Entity<Cotizacion>().HasRequired(c => c.Producto)
            //    .WithMany(p => p.Cotizacions).HasForeignKey(c => c.IDProducto);

            modelBuilder.Entity<CotizacionDet>().HasKey(c => c.IDCotizacionDet);
            modelBuilder.Entity<CotizacionDet>().HasIndex(c => c.IDCotizacionDet);
            modelBuilder.Entity<CotizacionDet>().HasRequired(c => c.Cotizacion)
                .WithMany(c => c.CotizacionDets).HasForeignKey(c => c.IDCotizacion);

            modelBuilder.Entity<Costos>().HasKey(c => c.IDCosto);
            modelBuilder.Entity<Costos>().HasIndex(c => c.IDComponente);
            modelBuilder.Entity<Costos>().HasIndex(c => c.IDProducto);
            modelBuilder.Entity<Costos>().HasRequired<Componente>(c => c.Componente)
                .WithMany(c => c.Costos).HasForeignKey(c => c.IDComponente);
            //modelBuilder.Entity<Costos>().HasRequired<Producto>(c => c.Producto)
            //    .WithMany(c => c.Costos).HasForeignKey(c => c.IDProducto);

            modelBuilder.Entity<TipoCosto>().HasKey(t => t.IDTipoCosto);


            

        }

    }


}