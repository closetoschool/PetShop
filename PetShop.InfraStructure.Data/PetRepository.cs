using System.Collections.Generic;
using PetShop.Core.DomainServices;
using PetShop.Core.Entity;

namespace PetShop.InfraStructure.Data
{
    public class PetRepository: IPetRepository
    {
        public List<Pet> GetPets()
        {
            throw new System.NotImplementedException();
        }

        public Pet GetPet(int id)
        {
            throw new System.NotImplementedException();
        }

        public Pet AddPet(Pet pet)
        {
            throw new System.NotImplementedException();
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