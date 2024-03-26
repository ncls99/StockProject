using Microsoft.AspNetCore.Mvc;
using StockProject.Models;
using StockProject.Services;

namespace StockProject.Controllers
{
    [Route("api/[controller]/")]
    public class ProductController : ControllerBase
    {
        IProductService productService;
        private readonly ILogger<ProductController> _logger;


        public ProductController(IProductService service, ILogger<ProductController> logger
            )
        {
            productService = service;
            _logger = logger;
        }

        [HttpGet]
        [Route("get")]
        public ActionResult Get()
        {
            try
            {
                return Ok(productService.Get());
            }
            catch (Exception ex)
            {
                var message = $"Ha ocurrido un error al buscar los productos {ex.Message}";
                _logger.LogError(message, ex);

                return StatusCode(StatusCodes.Status400BadRequest, message);

            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id) 
        {
            try
            {
                return Ok(await productService.GetProductById(id));
            }
            catch (Exception ex) 
            {
                var message = $"Ha ocurrido un error al buscar el producto {ex.Message}";
                _logger.LogError(message, ex);

                return StatusCode(StatusCodes.Status400BadRequest, message);
            }
        }

        // Post: Product/Post
        [HttpPost]
        [Route("post")]
        public ActionResult Post([FromBody] Product product)
        {

            try
            {
                var savedProducts = productService.Save(product);
                var message = $"Ha ocurrido un error con el registro del producto";
                if (savedProducts)
                {
                    return Ok();
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, message);
                }
            }
            catch (Exception ex)
            {
                var message = $"Ocurrió un error al registrar el producto {ex.Message}";
                _logger.LogError(ex, message);

                return StatusCode(StatusCodes.Status500InternalServerError, message);

            }
        }

        // Put: Product/Update/id
        [HttpPut("{id}")]
        public ActionResult Update(Guid id, [FromBody] Product product)
        {
            try
            {         
                productService.Update(id, product);
                return Ok();
            }
            catch(Exception ex) 
            {
                var message = $"Ocurrió un error al actualizar el producto {ex.Message}";
                _logger.LogError(ex, message);

                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }
        }

        // Delete: Product/Delete/5

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            { 
                productService.Delete(id);
                return Ok();
            }
            catch(Exception ex)
            {
                var message = $"Ocurrió un error al registrar el producto {ex.Message}";
                _logger.LogError(ex, message);

                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }
        }
    }
}
