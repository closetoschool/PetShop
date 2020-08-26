using System;
using System.Collections.Generic;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationServices.Services
{
    public class PetService: IPetService
    {
        public List<Pet> GetPets()
        {
            throw new NotImplementedException();
        }

        public Pet GetPet(int id)
        {
            throw new NotImplementedException();
        }

        public Pet AddPet(int id, string name, string type, DateTime birthdate, DateTime soldDate, string color, string previousOwner,
            double price)
        {
            throw new NotImplementedException();
        }

        public Pet UpdatePet(Pet pet)
        {
            throw new NotImplementedException();
        }

        public Pet DeletePet(Pet pet)
        {
            throw new NotImplementedException();
        }
    }
}