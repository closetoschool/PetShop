using System.Collections.Generic;
using System.IO;
using System.Linq;
using PetShop.Core.DomainServices;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationServices.Services
{
    public class OwnerService: IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }
        
        public List<Owner> GetOwners()
        {
            return _ownerRepository.ReadOwners().ToList();
        }
        
        public Owner GetOwner(int id)
        {
            return _ownerRepository.ReadOwnerById(id);
        }

        public List<Owner> SearchOwners(string searchField, string searchValue)
        {
            if (searchField == null)
            {
                throw new InvalidDataException("OwnerSearchFieldCannotBeNull");
            }

            if (searchValue == null)
            {
                throw new InvalidDataException("OwnerSearchValueCannotBeNull");
            }

            return _ownerRepository.SearchOwners(searchField, searchValue);
        }

        public Owner AddOwner(Owner owner) 
        {
            return _ownerRepository.AddOwner(owner);
        }

        public Owner UpdateOwner(Owner owner)
        {
            return _ownerRepository.UpdateOwner(owner);
        }

        public Owner DeleteOwner(int id)
        {
            return _ownerRepository.DeleteOwner(id);
        }
    }
}