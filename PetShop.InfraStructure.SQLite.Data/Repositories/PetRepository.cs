using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PetShop.Core.DomainServices;
using PetShop.Core.Entity;

namespace PetShop.InfraStructure.SQLite.Data.Repositories
{
    public class PetRepository: IPetRepository
    {
        private PetShopLiteContext _ctx;

        public PetRepository(PetShopLiteContext ctx)
        {
            _ctx = ctx;
        }
        public IEnumerable<Pet> ReadPets()
        {
            throw new System.NotImplementedException();
        }

        public Pet ReadPetById(int id)
        {
            return _ctx.Pets
                .Include(p => p.Owners)
                .FirstOrDefault(p => p.Id == id);
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
            var petDb = _ctx.Pets.Add(pet);
            _ctx.SaveChanges();
            return petDb.Entity;
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