using Microsoft.AspNetCore.Mvc;
using StockProject.Models;
using StockProject.Services;

namespace StockProject.Controllers
{
    [Route("api/order/[controller]")]

    public class OrderController : ControllerBase
    {
        IOrderService orderService;

        public OrderController(IOrderService service)
        {
            orderService = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(orderService.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Order order)
        {
            orderService.Save(order);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Order order)
        {
            orderService.Update(id, order);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            orderService.Delete(id);
            return Ok();
        }
    }
}
