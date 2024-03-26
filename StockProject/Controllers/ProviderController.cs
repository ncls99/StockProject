using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StockProject.Models;
using StockProject.Services;

namespace StockProject.Controllers
{
    [Route("api/[controller]")]
    public class ProviderController : ControllerBase
    {
        IProviderService providerService;
        private readonly ILogger<ProviderController> _logger;


        public ProviderController(IProviderService service, ILogger<ProviderController> logger)
        {
            providerService = service;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            { 
                return Ok(providerService.Get());
            }
            catch (Exception ex) 
            {
                var message = $"Ha ocurrido un error al buscar los proveedores {ex.Message}";
                _logger.LogError(message, ex);

                return StatusCode(StatusCodes.Status400BadRequest, message);
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProviderById(Guid id)
        {
            try
            {
                return Ok(await providerService.GetProviderById(id));
            }
            catch (Exception ex)
            {
                var message = $"Ha ocurrido un error al buscar el proveedor {ex.Message}";
                _logger.LogError(message, ex);

                return StatusCode(StatusCodes.Status400BadRequest, message);
            }
        }

        // Post: Provider/Post
        [HttpPost]
        [Route("post")]
        public ActionResult Post([FromBody] Provider provider)
        {
            try
            {
                var savedProducts = providerService.Save(provider);
                var message = $"Ha ocurrido un error con el registro del proveedor";
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
                var message = $"Ocurrió un error al registrar el proveedor {ex.Message}";
                _logger.LogError(ex, message);

                return StatusCode(StatusCodes.Status500InternalServerError, message);

            }
        }

        // Put: Provider/Update/id
        [HttpPut("{id}")]
        public ActionResult Update(Guid id, [FromBody] Provider provider)
        {
            try
            {
                providerService.Update(id, provider);
                return Ok();
            }
            catch (Exception ex)
            {
                var message = $"Ha ocurrido un error al actualizar el proveedor {ex.Message}";
                _logger.LogError(message, ex);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // Delete: Provider/Delete/5

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                providerService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                var message = $"Ha ocurrido un error al borrar el proveedor {ex.Message}";
                _logger.LogError(message, ex);

                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

        }
    }
}
