using System.Collections.Generic;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationServices
{
    public interface ITypeService
    {
        public List<Type> GetTypes();
        public Type GetType(int id);
        public List<Type> SearchTypes(string searchField, string searchValue);
        public Type AddType(Type owner);
        public Type UpdateType(Type pet);
        public Type DeleteType(int id);
    }
}