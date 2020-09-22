using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PetShop.Core.DomainServices;
using Type = PetShop.Core.Entity.Type;

namespace PetShop.InfraStructure.SQLite.Data.Repositories
{
    public class TypeRepository: ITypeRepository
    {
        private PetShopLiteContext _ctx;

        public TypeRepository(PetShopLiteContext ctx)
        {
            _ctx = ctx;
        }
        public IEnumerable<Type> ReadTypes()
        {
            return _ctx.Types;
        }

        public Type ReadTypeById(int id)
        {
            return _ctx.Types.FirstOrDefault(t => t.Id == id);
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
            var typeFromDb = _ctx.Types.Add(type);
            _ctx.SaveChanges();
            return typeFromDb.Entity;
        }

        public Type UpdateType(Type type)
        {
            var typeFromDb = _ctx.Types.Update(type);
            _ctx.SaveChanges();
            return typeFromDb.Entity;
        }

        public Type DeleteType(int id)
        {
            var type = _ctx.Types.First(t => t.Id == id);
            _ctx.Types.Remove(type);
            return type;
        }
    }
}