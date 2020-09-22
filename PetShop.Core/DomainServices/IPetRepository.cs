using System.Collections.Generic;
using PetShop.Core.Entity;

namespace PetShop.Core.DomainServices
{
    public interface IPetRepository
    {
        IEnumerable<Pet> ReadPets();
        public Pet ReadPetById(int id);
        public List<Pet> SearchPets(string searchField, string searchValue);
        public List<Pet> SortByPrice(string direction, int limit = 0);
        public Pet AddPet(Pet pet);
        public Pet UpdatePet(Pet pet);
        public Pet DeletePet(int id);
    }
}