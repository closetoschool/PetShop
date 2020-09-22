using System;
using System.Collections.Generic;

namespace PetShop.Core.Entity
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime SoldDate { get; set; }
        public string Color { get; set; }
        public string PreviousOwner { get; set; }
        public double Price { get; set; }
        public List<Owner> Owners { get; set; }
        public Type Type { get; set; }
    }
}