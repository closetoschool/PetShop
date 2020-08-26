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
            IPetRepository _petRepository = new PetRepository();
            IPetService _petService = new PetService(_petRepository);
            var printer = new Printer(_petService);
        }
    }
}