using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ShopMaMonolitic.Data.Entities;

namespace ShopMaMonolitic.Data.Context
{
    public class ShopContext : DbContext
    {
        #region"Constructor"
        public ShopContext(DbContextOptions<ShopContext> options)
        {
        }
        #endregion
        #region"SalesCustomers Dbsets"
        public DbSet<SalesCustomers> SalesCustomers { get; set; }
        //Hacer los otros de segun mi rama.
        #endregion
    }
} 