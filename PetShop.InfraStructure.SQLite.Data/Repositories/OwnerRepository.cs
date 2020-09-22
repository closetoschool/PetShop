using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PetShop.Core.DomainServices;
using PetShop.Core.Entity;

namespace PetShop.InfraStructure.SQLite.Data.Repositories
{
    public class OwnerRepository: IOwnerRepository
    {
        private PetShopLiteContext _ctx;

        public OwnerRepository(PetShopLiteContext ctx)
        {
            _ctx = ctx;
        }
        public IEnumerable<Owner> ReadOwners()
        {
            return _ctx.Owners;
        }

        public Owner ReadOwnerById(int id)
        {
            return _ctx.Owners.FirstOrDefault(o => o.Id == id);
        }

        public List<Owner> SearchOwners(string searchField, string searchValue)
        {
            if (searchField == null)
            {
                throw new InvalidDataException("OwnerSearchFieldCannotBeNull");
            }

            if (searchValue == null)
            {
                throw new InvalidDataException("OwnerSearchValueCannotBeNull");
            }
            
            switch (searchField.ToLower())
            {
                case "id":
                    int number;
                    if (Int32.TryParse(searchValue, out number))
                    {
                        if (number < 1)
                        {
                            throw new InvalidDataException("OwnerIdMustBeAboveZero");
                        }
                        // customer?.id ? = skip null.
                        return ReadOwners().ToList().FindAll(owner => owner?.Id == int.Parse(searchValue));
                    }

                    throw new InvalidDataException("OwnerSearchValueWithFieldTypeIdMustBeANumber");
                case "firstname":
                    return ReadOwners().ToList().FindAll(owner => owner?.FirstName == searchValue);
                case "lastname":
                    return ReadOwners().ToList().FindAll(owner => owner?.LastName == searchValue);
                case "address":
                    return ReadOwners().ToList().FindAll(owner => owner?.Address == searchValue);
                case "phonenumber":
                    return ReadOwners().ToList().FindAll(owner => owner?.PhoneNumber == searchValue);
                case "email":
                    return ReadOwners().ToList().FindAll(owner => owner?.Email == searchValue);
                default:
                    throw new InvalidDataException("OwnerSearchFieldNotFound");
            }
        }

        public Owner AddOwner(Owner owner)
        {
            var ownerFromDb = _ctx.Owners.Add(owner);
            _ctx.SaveChanges();
            return ownerFromDb.Entity;
        }

        public Owner UpdateOwner(Owner owner)
        {
            var ownerFromDb = _ctx.Owners.Update(owner);
            _ctx.SaveChanges();
            return ownerFromDb.Entity;
        }

        public Owner DeleteOwner(int id)
        {
            var owner = _ctx.Owners.First(o => o.Id == id);
            _ctx.Owners.Remove(owner);
            return owner;
        }
    }
}