using System.Collections.Generic;
using PetShop.Core.DomainServices;
using PetShop.Core.Entity;

namespace PetShop.InfraStructure.Data
{
    public class PetRepository: IPetRepository
    {
        private int _id = 1;
        private List<Pet> _pets = new List<Pet>();
        public IEnumerable<Pet> ReadPets()
        {
            return _pets;
        }

        public Pet GetPet(int id)
        {
            throw new System.NotImplementedException();
        }

        public Pet AddPet(Pet pet)
        {
            pet.Id = _id++;
            _pets.Add(pet);
            return pet;
        }

        public Pet UpdatePet(Pet pet)
        {
            throw new System.NotImplementedException();
        }

        public Pet DeletePet(Pet pet)
        {
            throw new System.NotImplementedException();
        }
    }
}