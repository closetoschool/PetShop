using System;
using System.Collections.Generic;
using System.Linq;
using PetShop.Core.DomainServices;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationServices.Services
{
    public class PetService: IPetService
    {
        private readonly IPetRepository _petRepository;

        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }
        
        public List<Pet> GetPets()
        {
            return _petRepository.ReadPets().ToList();
        }
        
        public Pet GetPet(int id)
        {
            throw new NotImplementedException();
        }

        public Pet AddPet(string name, string type, DateTime birthdate, DateTime soldDate, string color, string previousOwner,
            double price)
        {
            var pet = new Pet
            {
                Name = name,
                Type = type,
                BirthDate = birthdate,
                SoldDate = soldDate,
                Color = color,
                PreviousOwner = previousOwner,
                Price = price,
            };
            return _petRepository.AddPet(pet);
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