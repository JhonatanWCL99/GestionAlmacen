using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PruebaTecnicaSitec.Models;

namespace PruebaTecnicaSitec.Data
{
    public class AlmacenDB:DbContext
    {
        public AlmacenDB(DbContextOptions<AlmacenDB> options):base(options) { }
        public DbSet<Producto> Productos => Set<Producto>();   
        public DbSet<Inventario> Inventarios => Set<Inventario>();
        public DbSet<DetalleInventario> DetallesInventario => Set<DetalleInventario>();
        public DbSet<Venta> Ventas =>Set<Venta>();
        public DbSet<DetalleVenta> DetallesVenta =>Set<DetalleVenta>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventario>().HasMany(d =>d.detallesInventario);
            modelBuilder.Entity<Venta>().HasMany(d =>d.detallesVenta);
        }

        internal Task<Inventario> FindAsync(int idInventario)
        {
            throw new NotImplementedException();
        }
    }
}
