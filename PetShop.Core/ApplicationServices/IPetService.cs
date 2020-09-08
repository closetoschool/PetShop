using System;
using System.Collections.Generic;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationServices
{
    public interface IPetService
    {
        public List<Pet> GetPets();
        public Pet GetPet(int id);
        public List<Pet> SearchPets(string searchField, string searchValue);
        public List<Pet> SortByPrice(string direction, int limit = 0);
        public Pet AddPet(Pet pet);
        public Pet UpdatePet(Pet pet);
        public Pet DeletePet(int id);
    }
}