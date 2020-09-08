using System.Collections.Generic;
using PetShop.Core.Entity;

namespace PetShop.InfraStructure.Data
{
    public static class FakeDB
    {
        public static int _id = 1;
        public static List<Pet> _pets = new List<Pet>();
    }
}