using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PetShop.Core.DomainServices;
using PetShop.Core.Entity;

namespace PetShop.InfraStructure.Data
{
    public class OwnerRepository: IOwnerRepository
    {

        public OwnerRepository()
        {
            //
        }

        public IEnumerable<Owner> ReadOwners()
        {
            return FakeDb.Owners;
        }

        public Owner ReadOwnerById(int id)
        {
            return FakeDb.Owners.FirstOrDefault(o => o.Id == id);
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
            owner.Id = FakeDb.OwnerId++;
            FakeDb.Owners.Add(owner);
            return owner;
        }

        public Owner UpdateOwner(Owner owner)
        {
            var ownerFromDb = ReadOwnerById(owner.Id);
            if (ownerFromDb == null) return null;
            ownerFromDb.Id = owner.Id;
            ownerFromDb.FirstName = owner.FirstName;
            ownerFromDb.LastName = owner.LastName;
            ownerFromDb.Address = owner.Address;
            ownerFromDb.PhoneNumber = owner.PhoneNumber;
            ownerFromDb.Email = owner.Email;
            return ownerFromDb;
        }
        
        public Owner DeleteOwner(int id)
        {
            var owner = ReadOwnerById(id);
            if (owner == null) return null;
            FakeDb.Owners.Remove(owner);
            return owner;
        }
    }
}