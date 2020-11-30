using Microsoft.EntityFrameworkCore;
using api_stock.Models;

namespace api_stock.DataAccess
{
    public class DataAccessContext:DbContext{
        public DataAccessContext(DbContextOptions<DataAccessContext> options) : base(options)
        {       
        }

        public DbSet<AreaModel> tbl_area { get; set; }
        public DbSet<EmpleadoModel> tbl_empleado { get; set; }
        public DbSet<InventarioModel> tbl_inventario { get; set; }
        public DbSet<ProveedorModel> tbl_proveedor { get; set; }

        public DbSet<ProductoModel> tbl_producto { get; set; }

        public DbSet<EstadoModel> tbl_estado { get; set; }
        public DbSet<TipoProductoModel> tbl_tipo_producto { get; set; }

        protected override void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder);
        }
        public override int SaveChanges(){
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}