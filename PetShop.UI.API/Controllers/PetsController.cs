using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationServices;
using PetShop.Core.Entity;

namespace PetShop.UI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }
            
        [HttpGet]
        public IEnumerable<Pet> Get()
        {
            return _petService.GetPets();
        }
        
        // GET api/pets/5 -- READ By Id
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            if (id < 1) return BadRequest("Id must be greater then 0");
            
            return Ok(_petService.GetPet(id));
        }
        
        // POST api/pets -- CREATE
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            try
            {
                return Ok(_petService.AddPet(pet));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        // PUT api/pets/5 -- Update
        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet pet)
        {
            if (id < 1 || id != pet.Id)
            {
                return BadRequest("Parameter Id and order ID must be the same");
            }

            return Ok(_petService.UpdatePet(pet));
        }
        
        // DELETE api/pets/5
        [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id)
        {
            _petService.DeletePet(id);
            return Ok($"Pet with Id: {id} is Deleted");
        }
        
    }
}