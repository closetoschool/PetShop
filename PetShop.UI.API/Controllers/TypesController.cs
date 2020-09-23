using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationServices;
using Type = PetShop.Core.Entity.Type;

namespace PetShop.UI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class TypesController : ControllerBase
    {
        private readonly ITypeService _typeService;

        public TypesController(ITypeService typeService)
        {
            _typeService = typeService; 
        }
            
        // GET api/types
        [HttpGet]
        public IEnumerable<Type> Get()
        {
            return _typeService.GetTypes();
        }
        
        // GET api/types/5 -- READ By Id
        [HttpGet("{id}")]
        public ActionResult<Type> Get(int id)
        {
            if (id < 1) return BadRequest("Id must be greater then 0");

            var type = _typeService.GetType(id);

            if (type == null) return NotFound();

            return Ok(type);
        }
        
        // POST api/types -- CREATE
        [HttpPost]
        public ActionResult<Type> Post([FromBody] Type type)
        {
            try
            {
                var typeFromDb = _typeService.AddType(type);
                return Created($"api/types/{typeFromDb.Id}", typeFromDb);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        // PUT api/types/5 -- Update
        [HttpPut("{id}")]
        public ActionResult<Type> Put(int id, [FromBody] Type type)
        {
            if (id < 1) return BadRequest("Id must be greater then 0");
            
            if (id < 1 || id != type.Id)
            {
                return BadRequest("Parameter Id and order ID must be the same");
            }
            
            if (_typeService.GetType(id) == null) return NotFound();

            return Accepted(_typeService.UpdateType(type));
        }
        
        // DELETE api/types/5
        [HttpDelete("{id}")]
        public ActionResult<Type> Delete(int id)
        {
            if (id < 1) return BadRequest("Id must be greater then 0");
            
            if (_typeService.GetType(id) == null) return NotFound();
            
            _typeService.DeleteType(id);
            return Accepted($"Type with Id: {id} is Deleted");
        }
        
    }
}