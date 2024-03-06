using Microsoft.AspNetCore.Mvc;
using StockProject.Models;
using StockProject.Services;

namespace StockProject.Controllers
{
    [Route("api/sale/[controller]")]
    public class SaleController : ControllerBase
    {
        ISaleService saleService;

        public SaleController(ISaleService service)
        {
            saleService = service;
        }

        [HttpGet]
        public IActionResult Get() 
        {
            return Ok(saleService.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Sale sale) 
        {
            saleService.Save(sale);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Sale sale)
        {
            saleService.Update(id, sale);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            saleService.Delete(id);
            return Ok();
        }
    }

}
