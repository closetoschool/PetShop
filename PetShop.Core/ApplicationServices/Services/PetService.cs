using System.Collections.Generic;
using System.IO;
using System.Linq;
using PetShop.Core.DomainServices;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationServices.Services
{
    public class PetService: IPetService
    {
        private readonly IPetRepository _petRepository;

        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }
        
        public List<Pet> GetPets()
        {
            return _petRepository.ReadPets().ToList();
        }
        
        public Pet GetPet(int id)
        {
            return _petRepository.ReadPetById(id);
        }

        public List<Pet> SearchPets(string searchField, string searchValue)
        {
            if (searchField == null)
            {
                throw new InvalidDataException("PetSearchFieldCannotBeNull");
            }

            if (searchValue == null)
            {
                throw new InvalidDataException("PetSearchValueCannotBeNull");
            }

            return _petRepository.SearchPets(searchField, searchValue);
        }

        public List<Pet> SortByPrice(string direction, int limit = 0)
        {
            return _petRepository.SortByPrice(direction, limit);
        }

        public Pet AddPet(Pet pet) 
        {
            return _petRepository.AddPet(pet);
        }

        public Pet UpdatePet(Pet pet)
        {
            return _petRepository.UpdatePet(pet);
        }

        public Pet DeletePet(int id)
        {
            return _petRepository.DeletePet(id);
        }
    }
}