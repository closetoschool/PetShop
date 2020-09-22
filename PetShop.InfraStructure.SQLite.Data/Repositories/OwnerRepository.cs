using System.Collections.Generic;
using PetShop.Core.DomainServices;
using PetShop.Core.Entity;

namespace PetShop.InfraStructure.SQLite.Data.Repositories
{
    public class OwnerRepository: IOwnerRepository
    {
        private PetShopLiteContext _ctx;

        public OwnerRepository(PetShopLiteContext ctx)
        {
            _ctx = ctx;
        }
        public IEnumerable<Owner> ReadOwners()
        {
            throw new System.NotImplementedException();
        }

        public Owner ReadOwnerById(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Owner> SearchOwners(string searchField, string searchValue)
        {
            throw new System.NotImplementedException();
        }

        public Owner AddOwner(Owner owner)
        {
            var ownerFromDb = _ctx.Owners.Add(owner);
            _ctx.SaveChanges();
            return ownerFromDb.Entity;
        }

        public Owner UpdateOwner(Owner owner)
        {
            throw new System.NotImplementedException();
        }

        public Owner DeleteOwner(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}