using Microsoft.EntityFrameworkCore;
using ShopMaMonolitic.Data.Entities;

namespace ShopMaMonolitic.Data.Context;

public class ShopContext : DbContext
{

    #region "Constructor"
    public ShopContext(DbContextOptions<ShopContext> options) : base(options)
    {

    }
    #endregion

    #region "DbSet's"

    public DbSet<Products> Products { get; set; }
    public DbSet<Categories> Categories { get; set; }
    public DbSet<Suppliers> Suppliers { get; set; }

    #endregion

}