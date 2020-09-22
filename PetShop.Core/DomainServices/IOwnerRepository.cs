using System.Collections.Generic;
using PetShop.Core.Entity;

namespace PetShop.Core.DomainServices
{
    public interface IOwnerRepository
    {
        IEnumerable<Owner> ReadOwners();
        public Owner ReadOwnerById(int id);
        public List<Owner> SearchOwners(string searchField, string searchValue);
        public Owner AddOwner(Owner owner);
        public Owner UpdateOwner(Owner owner);
        public Owner DeleteOwner(int id);
    }
}