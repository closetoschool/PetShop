using System.Collections.Generic;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationServices
{
    public interface IOwnerService
    {
        public List<Owner> GetOwners();
        public Owner GetOwner(int id);
        public List<Owner> SearchOwners(string searchField, string searchValue);
        public Owner AddOwner(Owner owner);
        public Owner UpdateOwner(Owner pet);
        public Owner DeleteOwner(int id);
    }
}