using Microsoft.EntityFrameworkCore;
using ShopMaMonolitic.Data.Entities;

namespace ShopMaMonolitic.Data.Context;

public class ShopContext : DbContext
{
    #region"Constructor"

    // Constructor que recibe opciones de configuración del DbContext
    public ShopContext(DbContextOptions<ShopContext> options) : base(options)
    {
    }

    #endregion

    #region"SalesCustomers DbSt"

    public DbSet<SalesCustomers> SalesCustomers { get; set; }

    #endregion

    #region"SalesOrders DbSet"

    public DbSet<SalesOrders> SalesOrders { get; set; }

    #endregion

    #region "SalesOrdersDetails DbSet"

    public DbSet<SalesOrderDetails> SalesOrderDetails { get; set; }

    #endregion
}