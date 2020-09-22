using System.Collections.Generic;
using System.IO;
using System.Linq;
using PetShop.Core.DomainServices;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationServices.Services
{
    public class TypeService: ITypeService
    {
        private readonly ITypeRepository _typeRepository;

        public TypeService(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }
        
        public List<Type> GetTypes()
        {
            return _typeRepository.ReadTypes().ToList();
        }
        
        public Type GetType(int id)
        {
            return _typeRepository.ReadTypeById(id);
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

            return _typeRepository.SearchTypes(searchField, searchValue);
        }

        public Type AddType(Type type) 
        {
            return _typeRepository.AddType(type);
        }

        public Type UpdateType(Type type)
        {
            return _typeRepository.UpdateType(type);
        }

        public Type DeleteType(int id)
        {
            return _typeRepository.DeleteType(id);
        }
    }
}