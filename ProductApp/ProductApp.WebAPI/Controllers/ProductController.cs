using Microsoft.AspNetCore.Mvc;
using ProductApp.Business;
using ProductApp.Entities;

namespace ProductApp.WebAPI.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase{

        private readonly IProductService _service;
        public ProductController(IProductService service) => _service = service;

        [HttpGet] 
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id){
            var p = _service.GetById(id);
            return p==null ? NotFound() : Ok(p);
        }

        [HttpPost]
        public IActionResult Add(Product product){
            _service.Add(product);
            return CreatedAtAction(nameof(GetById), new {id = product.Id},product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Product product){
            if(id != product.Id) return BadRequest();
            _service.Update(product);
            return Ok(product);
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            _service.Delete(id);
            return Ok();
        }
    }
}
