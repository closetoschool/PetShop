using Microsoft.EntityFrameworkCore;
using PetShop.Core.Entity;

namespace PetShop.InfraStructure.SQLite.Data
{
    public class PetShopLiteContext: DbContext
    {
        public PetShopLiteContext(DbContextOptions<PetShopLiteContext> opt) : base(opt) {}
        
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Type> Types { get; set; }
    }
}