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
            InitData();
        }

        private void InitData()
        {
            FakeDB._pets = new List<Pet>
            {
                new Pet
                {
                    Id = FakeDB._id++,
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
                    Id = FakeDB._id++,
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
            return FakeDB._pets;
        }

        public Pet ReadPetById(int id)
        {
            return FakeDB._pets.
                Select(c => new Pet()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Type = c.Type,
                    BirthDate = c.BirthDate,
                    SoldDate = c.SoldDate,
                    Color = c.Color,
                    PreviousOwner = c.PreviousOwner,
                    Price = c.Price
                }).
                FirstOrDefault(c => c.Id == id);
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
                case "type":
                    return ReadPets().ToList().FindAll(pet => pet?.Type == searchValue);
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
            pet.Id = FakeDB._id++;
            FakeDB._pets.Add(pet);
            return pet;
        }

        public Pet UpdatePet(Pet pet)
        {
            var PetFromDB = ReadPetById(pet.Id);
            if (PetFromDB == null) return null;
            PetFromDB.Id = pet.Id;
            PetFromDB.Name = pet.Name;
            PetFromDB.Type = pet.Type;
            PetFromDB.BirthDate = pet.BirthDate;
            PetFromDB.SoldDate = pet.SoldDate;
            PetFromDB.Color = pet.Color;
            PetFromDB.PreviousOwner = pet.PreviousOwner;
            PetFromDB.Price = pet.Price;
            return PetFromDB;
        }
        
        public Pet DeletePet(int id)
        {
            var pet = ReadPetById(id);
            if (pet == null) return null;
            FakeDB._pets.Remove(pet);
            return pet;
        }
    }
}