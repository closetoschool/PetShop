using System;
using System.Collections.Generic;
using PetShop.Core.ApplicationServices;
using PetShop.Core.Entity;

namespace PetShop.UI
{
    public class Printer
    {
        private IPetService _petService;
        public Printer(IPetService petService)
        {
            _petService = petService;
        }

        internal void ListAllPets()
        {
            List<Pet> pets = _petService.GetPets();
            foreach (var pet in pets)
            {
                Console.WriteLine($"Cute {pet.Type} named {pet.Name} has the id {pet.Id} and is {pet.Color} and only costs {pet.Price}");
            }
        }

        internal void CreatePet()
        {
            Console.WriteLine("Type Pet Name");
            var name = Console.ReadLine();
            Console.WriteLine("Type Pet Type");
            var type = Console.ReadLine();
            Console.WriteLine("Type Pet Birthday");
            var birthday = Console.ReadLine();
            Console.WriteLine("Type Pet SoldDate");
            var soldDate = Console.ReadLine();
            Console.WriteLine("Type Pet Color");
            var color = Console.ReadLine();
            Console.WriteLine("Type Pet Previous Owner");
            var prevOwner = Console.ReadLine();
            Console.WriteLine("Type Pet Price");
            var price = Console.ReadLine();

            DateTime.TryParse(birthday, out var parsedBirthday);
            DateTime.TryParse(soldDate, out var parsedSoldDate);
            double.TryParse(price, out var parsedPrice);

            var pet = _petService.AddPet(name, type, parsedBirthday, parsedSoldDate, color, prevOwner, parsedPrice);
            Console.WriteLine($"Cute {pet.Type} named {pet.Name} has the id {pet.Id} and is {pet.Color} and only costs {pet.Price}");
        }
        
    }
}