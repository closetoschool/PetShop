using System;
using System.Collections.Generic;

namespace PetShop.Core.Entity
{
    public class Type
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Pet> Pets { get; set; }
    }
}