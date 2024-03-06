using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StockProject.Models;
using StockProject.Services;

namespace StockProject.Controllers
{
    [Route("api/provider/[controller]")]
    public class ProviderController : ControllerBase
    {
        IProviderService providerService;

        public ProviderController(IProviderService service)
        {
            providerService = service;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(providerService.Get());
        }

        // Post: Provider/Post/id
        [HttpPost]
        public ActionResult Post([FromBody] Provider provider)
        {
            providerService.Save(provider);
            return Ok();
        }

        // Put: Provider/Update/id
        [HttpPut("{id}")]
        public ActionResult Update(Guid id, [FromBody] Provider provider)
        {
            providerService.Update(id, provider);
            return Ok();
        }

        // Delete: Provider/Delete/5

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            providerService.Delete(id);
            return Ok();
        }
    }
}
