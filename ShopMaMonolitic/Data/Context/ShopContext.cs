using Microsoft.EntityFrameworkCore;
using ShopMaMonolitic.Data.Entities;

namespace ShopMaMonolitic.Data.Context
{
    public class ShopContext : DbContext
    {
        // Constructor que recibe opciones de configuración del DbContext
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
        }

        // DbSet para cada entidad del modelo de datos
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductionCategories> ProductionCategories { get; set; }
        public DbSet<ProductionSuppliers> ProductionSuppliers { get; set; }

    
       
    }
}
