using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationServices;
using PetShop.Core.Entity;

namespace PetShop.UI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnersController(IOwnerService ownerService)
        {
            _ownerService = ownerService; 
        }
            
        [HttpGet]
        public IEnumerable<Owner> Get()
        {
            return _ownerService.GetOwners();
        }
        
        // GET api/owners/5 -- READ By Id
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            if (id < 1) return BadRequest("Id must be greater then 0");

            var owner = _ownerService.GetOwner(id);
            
            if(owner == null) return NotFound(); 
            
            return Ok(owner);
        }
        
        // POST api/owners -- CREATE
        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner owner)
        {
            try
            {
                //return Ok(_ownerService.AddOwner(owner));
                var ownerFromDb = _ownerService.AddOwner(owner);
                return Created($"api/owners/{ownerFromDb.Id}", ownerFromDb);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        // PUT api/owners/5 -- Update
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner owner)
        {
            if (id < 1) return BadRequest("Id must be greater then 0");
            
            if (id != owner.Id)
            {
                return BadRequest("Parameter Id and order ID must be the same");
            }
            
            if (_ownerService.GetOwner(id) == null) return NotFound();

            return Accepted(_ownerService.UpdateOwner(owner));
        }
        
        // DELETE api/owners/5
        [HttpDelete("{id}")]
        public ActionResult<Owner> Delete(int id)
        {
            if (id < 1) return BadRequest("Id must be greater then 0");
            
            if (_ownerService.GetOwner(id) == null) return NotFound();
            
            _ownerService.DeleteOwner(id);
            return Accepted($"Owner with Id: {id} is Deleted");
        }
        
    }
}