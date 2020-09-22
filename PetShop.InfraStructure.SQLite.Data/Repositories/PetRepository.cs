using System;
using System.Collections.Generic;
using System.IO;
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
            return _ctx.Pets;
        }

        public Pet ReadPetById(int id)
        {
            return _ctx.Pets
                .Include(p => p.Owners)
                .FirstOrDefault(p => p.Id == id);
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
                    return ReadPets().ToList().FindAll(pet => Equals(pet?.Price, price));
                default:
                    throw new InvalidDataException("PetSearchFieldNotFound");
            }
        }

        public List<Pet> SortByPrice(string direction, int limit = 0)
        {
            List<Pet> results;

            results = direction.ToLower() == "asc" 
                ? ReadPets().OrderBy(p => p.Price).ToList() 
                : ReadPets().OrderByDescending(p => p.Price).ToList();

            return limit > 0 ? results.Take(limit).ToList() : results;
        }

        public Pet AddPet(Pet pet)
        {
            var petDb = _ctx.Pets.Add(pet);
            _ctx.SaveChanges();
            return petDb.Entity;
        }

        public Pet UpdatePet(Pet pet)
        {
            var petFromDb = _ctx.Pets.Update(pet);
            _ctx.SaveChanges();
            return petFromDb.Entity;
        }

        public Pet DeletePet(int id)
        {
            var pet = _ctx.Pets.First(p => p.Id == id);
            _ctx.Pets.Remove(pet);
            return pet;
        }
    }
}