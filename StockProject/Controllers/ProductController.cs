using Microsoft.AspNetCore.Mvc;
using StockProject.Models;
using StockProject.Services;

namespace StockProject.Controllers
{
    [Route("api/provider/[controller]")]
    public class ProductController : ControllerBase
    {
        IProductService productService;

        public ProductController(IProductService service)
        {
            productService = service;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(productService.Get());
        }

        // Post: Product/Post/id
        [HttpPost]
        public ActionResult Post([FromBody] Product product)
        {
            productService.Save(product);
            return Ok();
        }

        // Put: Product/Update/id
        [HttpPut("{id}")]
        public ActionResult Update(Guid id, [FromBody] Product product)
        {
            productService.Update(id, product);
            return Ok();
        }

        // Delete: Product/Delete/5

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            productService.Delete(id);
            return Ok();
        }
    }
}
