using System.Collections.Generic;
using PetShop.Core.DomainServices;
using PetShop.Core.Entity;

namespace PetShop.InfraStructure.MSSQL.Data
{
    public class PetRepository: IPetRepository
    {
        //private PetShopContext _ctx;
        public IEnumerable<Pet> ReadPets()
        {
            throw new System.NotImplementedException();
        }

        public Pet ReadPetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Pet> SearchPets(string searchField, string searchValue)
        {
            throw new System.NotImplementedException();
        }

        public List<Pet> SortByPrice(string direction, int limit = 0)
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

        public Pet DeletePet(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}