using System;
using System.Collections.Generic;
using PetShop.Core.DomainServices;
using PetShop.Core.Entity;

namespace PetShop.InfraStructure.Data
{
    public class PetRepository: IPetRepository
    {
        private int _id = 1;
        private List<Pet> _pets = new List<Pet>();

        public PetRepository()
        {
            InitData();
        }

        private void InitData()
        {
            _pets = new List<Pet>
            {
                new Pet
                {
                    Id = _id++,
                    Name = "Mickey",
                    Type = "Mouse",
                    BirthDate = DateTime.Now.AddYears(-5),
                    SoldDate = DateTime.Now.AddYears(-1),
                    Color = "Black",
                    PreviousOwner = "Disney",
                    Price = 10000000,
                },
                new Pet
                {
                    Id = _id++,
                    Name = "Pluto",
                    Type = "Dog",
                    BirthDate = DateTime.Now.AddYears(-4),
                    SoldDate = DateTime.Now.AddYears(-2),
                    Color = "Brown",
                    PreviousOwner = "Mickey",
                    Price = 10000,
                }
            };
        }

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