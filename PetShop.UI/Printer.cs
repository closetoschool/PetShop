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

        internal bool ShowMenu()
        {
            Console.WriteLine("************* MENU *************");
            Console.WriteLine("You have the following options:");
            Console.WriteLine("[0] List all pets");
            Console.WriteLine("[1] Show pet with id");
            Console.WriteLine("[2] Sort pet by price");
            Console.WriteLine("[3] Search for a pet");
            Console.WriteLine("[4] Create a new pet");
            Console.WriteLine("[5] Update an existing pet");
            Console.WriteLine("[6] Delete an existing pet");
            Console.WriteLine("[7] Exit Program");

            var textAnswer = Console.ReadLine();

            int.TryParse(textAnswer, out var answer);

            switch (answer)
            {
                case 0:
                    ListAllPets();
                    return true;
                case 1:
                    ShowPet();
                    return true;
                case 2:
                    SortPets();
                    return true;
                case 3:
                    SearchPet();
                    return true;
                case 4: 
                    CreatePet();
                    return true;
                case 5:
                    UpdatePet();
                    return true;
                case 6:
                    DeletePet();
                    return true;
                case 7:
                    Environment.Exit(0);
                    return false;
                default:
                    Console.WriteLine("Option not found, please try again.");
                    return true;
            }
        }

        private void SortPets()
        {
            Console.WriteLine("[0] Sort by price in ASC");
            Console.WriteLine("[1] Sort by price in DESC");
            var textAnswer = Console.ReadLine();
            int.TryParse(textAnswer, out var answer);
            
            Console.WriteLine("How many pets do you want to limit to?");
            var textLimit = Console.ReadLine();
            int.TryParse(textLimit, out var limit);

            string direction;
            
            switch (answer)
            {
                case 0:
                    Console.WriteLine("Searching in ASC");
                    direction = "asc";
                    break;
                case 1:
                    Console.WriteLine("Searching in DESC");
                    direction = "desc";
                    break;
                default:
                    Console.WriteLine("Could not interpret input | Searching in ASC");
                    direction = "asc";
                    break;
            }

            var pets = _petService.SortByPrice(direction, limit);
            
            foreach (var pet in pets)
            {
                Console.WriteLine($"Id : {pet.Id} | Name {pet.Name}, Type {pet.Type}, Birthday { pet.BirthDate }, SoldDate { pet.SoldDate }, Color {pet.Color}, PreviousOwner {pet.PreviousOwner}, Price {pet.Price}");
            }
        }

        private void ShowPet()
        {
            Console.WriteLine("Please enter id of pet to show");
            var textId = Console.ReadLine();
            int.TryParse(textId, out var id);
            var pet = _petService.GetPet(id);
            Console.WriteLine($"Cute {pet.Type} named {pet.Name} has the id {pet.Id} and is {pet.Color} and only costs {pet.Price}");
            Console.WriteLine("Details:");
            Console.WriteLine($"Id : {pet.Id} | Name {pet.Name}, Type {pet.Type}, Birthday { pet.BirthDate }, SoldDate { pet.SoldDate }, Color {pet.Color}, PreviousOwner {pet.PreviousOwner}, Price {pet.Price}");
        }

        private void DeletePet()
        {
            Console.WriteLine("Please enter id of pet to delete");
            var textId = Console.ReadLine();
            int.TryParse(textId, out var id);
            var pet = _petService.DeletePet(id);
            Console.WriteLine($"Poor { pet.Type } named { pet.Name } has been deleted");
        }

        private void UpdatePet()
        {
            Console.WriteLine("Please enter id of pet to update");
            var textId = Console.ReadLine();
            int.TryParse(textId, out var id);
            var pet = _petService.GetPet(id);
            Console.WriteLine($"You wish to update pet with following details:");
            Console.WriteLine($"Name {pet.Name}, Type {pet.Type}, Birthday { pet.BirthDate }, SoldDate { pet.SoldDate }, Color {pet.Color}, PreviousOwner {pet.PreviousOwner}, Price {pet.Price}");
            Console.WriteLine("Update the values:");
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

            pet.Name = name;
            pet.Type = type;
            pet.BirthDate = parsedBirthday;
            pet.SoldDate = parsedSoldDate;
            pet.Color = color;
            pet.PreviousOwner = prevOwner;
            pet.Price = parsedPrice;

            var updatedPet = _petService.UpdatePet(pet);
            Console.WriteLine("Pet has been updated, and now has the following values:");
            Console.WriteLine($"Name {updatedPet.Name}, Type {updatedPet.Type}, Birthday { updatedPet.BirthDate }, SoldDate { updatedPet.SoldDate }, Color {updatedPet.Color}, PreviousOwner {updatedPet.PreviousOwner}, Price {updatedPet.Price}");
        }

        private void SearchPet()
        {
            Console.WriteLine("Please enter search field");
            Console.WriteLine("You can search in id, name, type, birthday, solddate, color, previousowner and price");
            var searchField = Console.ReadLine();
            Console.WriteLine("Please enter search value");
            var searchValue = Console.ReadLine();
            var pets = _petService.SearchPets(searchField, searchValue);
            Console.WriteLine($"We found { pets.Count } pet(s)");
            foreach (var pet in pets)
            {
                Console.WriteLine($"Id : {pet.Id} | Name {pet.Name}, Type {pet.Type}, Birthday { pet.BirthDate }, SoldDate { pet.SoldDate }, Color {pet.Color}, PreviousOwner {pet.PreviousOwner}, Price {pet.Price}");
            }
        }

        internal void ListAllPets()
        {
            var pets = _petService.GetPets();
            foreach (var pet in pets)
            {
                Console.WriteLine($"Id: {pet.Id} | Cute {pet.Type} named {pet.Name} has the id {pet.Id} and is {pet.Color} and only costs {pet.Price}");
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

            var pet = _petService.AddPet(
                new Pet
                {
                    Name = name,
                    Type = type,
                    BirthDate = parsedBirthday,
                    SoldDate = parsedSoldDate,
                    Color = color,
                    PreviousOwner = prevOwner,
                    Price = parsedPrice
                }
            );
            
            Console.WriteLine($"{ pet.Name } was added to the database");
        }
        
    }
}