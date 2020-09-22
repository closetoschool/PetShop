using System.Collections.Generic;
using PetShop.Core.Entity;

namespace PetShop.Core.DomainServices
{
    public interface ITypeRepository
    {
        IEnumerable<Type> ReadTypes();
        public Type ReadTypeById(int id);
        public List<Type> SearchTypes(string searchField, string searchValue);
        public Type AddType(Type owner);
        public Type UpdateType(Type owner);
        public Type DeleteType(int id);
    }
}