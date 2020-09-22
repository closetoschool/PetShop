using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationServices;
using Type = PetShop.Core.Entity.Type;

namespace PetShop.UI.API.Controllers
{
    [ApiController]
    [Route("api/pettype")]
    
    public class TypesController : ControllerBase
    {
        private readonly ITypeService _typeService;

        public TypesController(ITypeService typeService)
        {
            _typeService = typeService; 
        }
            
        [HttpGet]
        public IEnumerable<Type> Get()
        {
            return _typeService.GetTypes();
        }
        
        // GET api/pettype/5 -- READ By Id
        [HttpGet("{id}")]
        public ActionResult<Type> Get(int id)
        {
            if (id < 1) return BadRequest("Id must be greater then 0");
            
            return Ok(_typeService.GetType(id));
        }
        
        // POST api/pettype -- CREATE
        [HttpPost]
        public ActionResult<Type> Post([FromBody] Type type)
        {
            try
            {
                return Ok(_typeService.AddType(type));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        // PUT api/pettype/5 -- Update
        [HttpPut("{id}")]
        public ActionResult<Type> Put(int id, [FromBody] Type type)
        {
            if (id < 1 || id != type.Id)
            {
                return BadRequest("Parameter Id and order ID must be the same");
            }

            return Ok(_typeService.UpdateType(type));
        }
        
        // DELETE api/pettype/5
        [HttpDelete("{id}")]
        public ActionResult<Type> Delete(int id)
        {
            _typeService.DeleteType(id);
            return Ok($"Type with Id: {id} is Deleted");
        }
        
    }
}