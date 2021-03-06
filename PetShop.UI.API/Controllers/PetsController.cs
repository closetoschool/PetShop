using System;
using System.Collections.Generic;
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
            
            var pet = _petService.GetPet(id);

            if (pet == null) return NotFound();
            
            return Ok(pet);
        }
        
        // POST api/pets -- CREATE
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            try
            {
                var petFromDb = _petService.AddPet(pet);
                return Created($"api/pets/{petFromDb.Id}", petFromDb);
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
            if (id < 1) return BadRequest("Id must be greater then 0");
            
            if (id < 1 || id != pet.Id)
            {
                return BadRequest("Parameter Id and pet ID must be the same");
            }
            
            if (_petService.GetPet(id) == null) return NotFound();

            return Accepted(_petService.UpdatePet(pet));
        }
        
        // DELETE api/pets/5
        [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id)
        {
            if (id < 1) return BadRequest("Id must be greater then 0");
            
            if (_petService.GetPet(id) == null) return NotFound();
            
            _petService.DeletePet(id);
            return Accepted($"Pet with Id: {id} is Deleted");
        }
        
    }
}