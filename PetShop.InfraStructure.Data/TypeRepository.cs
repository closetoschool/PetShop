using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PetShop.Core.DomainServices;
using PetShop.Core.Entity;
using Type = PetShop.Core.Entity.Type;

namespace PetShop.InfraStructure.Data
{
    public class TypeRepository: ITypeRepository
    {

        public TypeRepository()
        {
            //
        }

        public IEnumerable<Type> ReadTypes()
        {
            return FakeDb.Types;
        }

        public Type ReadTypeById(int id)
        {
            return FakeDb.Types.FirstOrDefault(t => t.Id == id);
        }

        public List<Type> SearchTypes(string searchField, string searchValue)
        {
            if (searchField == null)
            {
                throw new InvalidDataException("TypeSearchFieldCannotBeNull");
            }

            if (searchValue == null)
            {
                throw new InvalidDataException("TypeSearchValueCannotBeNull");
            }
            
            switch (searchField.ToLower())
            {
                case "id":
                    int number;
                    if (Int32.TryParse(searchValue, out number))
                    {
                        if (number < 1)
                        {
                            throw new InvalidDataException("TypeIdMustBeAboveZero");
                        }
                        return ReadTypes().ToList().FindAll(type => type?.Id == int.Parse(searchValue));
                    }

                    throw new InvalidDataException("TypeSearchValueWithFieldTypeIdMustBeANumber");
                case "name":
                    return ReadTypes().ToList().FindAll(type => type?.Name == searchValue);
                default:
                    throw new InvalidDataException("TypeSearchFieldNotFound");
            }
        }

        public Type AddType(Type type)
        {
            type.Id = FakeDb.TypeId++;
            FakeDb.Types.Add(type);
            return type;
        }

        public Type UpdateType(Type type)
        {
            var typeFromDb = ReadTypeById(type.Id);
            if (typeFromDb == null) return null;
            typeFromDb.Id = type.Id;
            typeFromDb.Name = type.Name;
            return typeFromDb;
        }
        
        public Type DeleteType(int id)
        {
            var type = ReadTypeById(id);
            if (type == null) return null;
            FakeDb.Types.Remove(type);
            return type;
        }
    }
}