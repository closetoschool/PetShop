using Microsoft.EntityFrameworkCore;
using PetShop.Core.Entity;

namespace PetShop.InfraStructure.MSSQL.Data
{
    public class PetShopContext: DbContext
    {
        public PetShopContext(DbContextOptions<PetShopContext> opt) : base(opt)
        {
            
        }
        
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }
    }
}