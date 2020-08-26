using System.Collections.Generic;
using PetShop.Core.Entity;

namespace PetShop.Core.DomainServices
{
    public interface IPetRepository
    {
        public List<Pet> GetPets();
        public Pet GetPet(int id);
        public Pet AddPet(Pet pet);
        public Pet UpdatePet(Pet pet);
        public Pet DeletePet(Pet pet);
    }
}