using System;
using PetShop.Core.ApplicationServices;
using PetShop.Core.ApplicationServices.Services;
using PetShop.Core.DomainServices;
using PetShop.InfraStructure.Data;

namespace PetShop.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            IPetRepository petRepository = new PetRepository();
            IPetService petService = new PetService(petRepository);
            var printer = new Printer(petService);
            
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = printer.ShowMenu();
            }

            printer.ListAllPets();
            printer.CreatePet();
            printer.ListAllPets();
        }
    }
}