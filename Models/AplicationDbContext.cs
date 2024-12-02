using Microsoft.EntityFrameworkCore;
namespace P_SGI_BE.Models
{
    public class AplicationDbContext: DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options) { }
        public DbSet<Propietarios> Propietarios { get; set; }
        public DbSet<MetodoPago> MetodoPago { get; set;}
        public DbSet<TipoProducto> TipoProducto { get; set; }
        public DbSet<Medidas> Medidas { get; set; }
        public DbSet<Servicios> Servicios { get; set; }
        public DbSet<Proveedores> Proveedores { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Inventario> Inventario { get; set; }
        public DbSet<MovimientosInventario> MovimientosInventarios { get; set; }
        public DbSet<Ventas> Ventas { get; set; }
        public DbSet<MovimientosVenta> MovimientosVentas { get; set; }
        public DbSet<Usuarios> Usuarios { get;set; }
        public DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public DbSet<Costos> Costos { get; set; }
        public DbSet<Recetas> Recetas { get; set; }
    }
}
