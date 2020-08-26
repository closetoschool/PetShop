using System;
using System.Collections.Generic;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationServices
{
    public interface IPetService
    {
        public List<Pet> GetPets();
        //public Pet GetPet(int id);
        public Pet AddPet(string name, string type, DateTime birthdate, DateTime soldDate, string color, string previousOwner, double price);
        //public Pet UpdatePet(Pet pet);
        //public Pet DeletePet(Pet pet);
    }
}