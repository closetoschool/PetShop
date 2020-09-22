using System.Collections.Generic;
using PetShop.Core.Entity;

namespace PetShop.InfraStructure.Data
{
    public static class FakeDb
    {
        public static int PetId = 1;
        public static List<Pet> Pets = new List<Pet>();
        
        public static int OwnerId = 1;
        public static List<Owner> Owners = new List<Owner>();
        
        public static int TypeId = 1;
        public static List<Type> Types = new List<Type>();
    }
}