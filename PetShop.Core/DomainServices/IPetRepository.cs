using System.Collections.Generic;
using System;
using PetShop.Core.Entity;

namespace PetShop.Core.DomainServices
{
    public interface IPetRepository
    {
        IEnumerable<Pet> ReadPets();
        //public Pet GetPet(int id);
        public Pet AddPet(Pet pet);
        //public Pet UpdatePet(Pet pet);
        //public Pet DeletePet(Pet pet);
    }
}