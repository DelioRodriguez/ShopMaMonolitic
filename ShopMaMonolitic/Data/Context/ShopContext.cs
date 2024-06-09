using Microsoft.EntityFrameworkCore;
using ShopMaMonolitic.Data.Entities;

namespace ShopMaMonolitic.Data.Context;

public class ShopContext : DbContext
{
    public ShopContext(DbContextOptions<ShopContext> options) : base(options)
    {

    }

    public DbSet<Sta>
}