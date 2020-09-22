using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PetShop.Core.DomainServices;
using PetShop.Core.Entity;

namespace PetShop.InfraStructure.Data
{
    public class PetRepository: IPetRepository
    {

        public PetRepository()
        {
            //InitData();
        }

        private void InitData()
        {
            FakeDb.Pets.Add(new Pet
            {
                Id = FakeDb.PetId++,
                Name = "Mickey",
                BirthDate = DateTime.Now.AddYears(-5),
                SoldDate = DateTime.Now.AddYears(-1),
                Color = "Black",
                PreviousOwner = "Disney",
                Price = 10000000,
            });
            FakeDb.Pets.Add(new Pet
            {
                Id = FakeDb.PetId++,
                Name = "Pluto",
                BirthDate = DateTime.Now.AddYears(-4),
                SoldDate = DateTime.Now.AddYears(-2),
                Color = "Brown",
                PreviousOwner = "Mickey",
                Price = 10000,
            });
        }

        public IEnumerable<Pet> ReadPets()
        {
            return FakeDb.Pets;
        }

        public Pet ReadPetById(int id)
        {
            return FakeDb.Pets.FirstOrDefault(p => p.Id == id);
        }

        public List<Pet> SearchPets(string searchField, string searchValue)
        {
            if (searchField == null)
            {
                throw new InvalidDataException("PetSearchFieldCannotBeNull");
            }

            if (searchValue == null)
            {
                throw new InvalidDataException("PetSearchValueCannotBeNull");
            }
            
            switch (searchField.ToLower())
            {
                case "id":
                    int number;
                    if (Int32.TryParse(searchValue, out number))
                    {
                        if (number < 1)
                        {
                            throw new InvalidDataException("PetIdMustBeAboveZero");
                        }
                        // customer?.id ? = skip null.
                        return ReadPets().ToList().FindAll(pet => pet?.Id == int.Parse(searchValue));
                    }

                    throw new InvalidDataException("PetSearchValueWithFieldTypeIdMustBeANumber");
                case "name":
                    return ReadPets().ToList().FindAll(pet => pet?.Name == searchValue);
                case "birthday":
                    DateTime.TryParse(searchValue, out var birth);
                    return ReadPets().ToList().FindAll(pet => pet?.BirthDate == birth);
                case "solddate":
                    DateTime.TryParse(searchValue, out var sold);
                    return ReadPets().ToList().FindAll(pet => pet?.SoldDate == sold);
                case "color":
                    return ReadPets().ToList().FindAll(pet => pet?.Color == searchValue);
                case "previousowner":
                    return ReadPets().ToList().FindAll(pet => pet?.PreviousOwner == searchValue);
                case "price":
                    Double.TryParse(searchValue, out var price);
                    return ReadPets().ToList().FindAll(pet => pet?.Price == price);
                default:
                    throw new InvalidDataException("PetSearchFieldNotFound");
            }
        }

        public List<Pet> SortByPrice(string direction, int limit = 0)
        {
            List<Pet> results;

            if (direction.ToLower() == "asc")
            {
                results = ReadPets().OrderBy(p => p.Price).ToList();
            }
            else
            {
                results = ReadPets().OrderByDescending(p => p.Price).ToList();
            }

            return limit > 0 ? results.Take(limit).ToList() : results;
        }

        public Pet AddPet(Pet pet)
        {
            pet.Id = FakeDb.PetId++;
            FakeDb.Pets.Add(pet);
            return pet;
        }

        public Pet UpdatePet(Pet pet)
        {
            var petFromDb = ReadPetById(pet.Id);
            if (petFromDb == null) return null;
            petFromDb.Id = pet.Id;
            petFromDb.Name = pet.Name;
            petFromDb.BirthDate = pet.BirthDate;
            petFromDb.SoldDate = pet.SoldDate;
            petFromDb.Color = pet.Color;
            petFromDb.PreviousOwner = pet.PreviousOwner;
            petFromDb.Price = pet.Price;
            return petFromDb;
        }
        
        public Pet DeletePet(int id)
        {
            var pet = ReadPetById(id);
            if (pet == null) return null;
            FakeDb.Pets.Remove(pet);
            return pet;
        }
    }
}