using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProyectoIdentity.Models;

namespace ProyectoIdentity.Datos
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUsuario> AppUsuarios { get; set; }
        public DbSet<Almacen> Almacenes { get; set; }
        public DbSet<GrupoCliente> GrupoClientes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<GrupoProducto> GrupoProductos { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<CondicionPago> CondicionesPago { get; set; }
        public DbSet<MetodoPago> MetodosPago { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<FacturaItem> FacturaItems { get; set; }

    }
}
