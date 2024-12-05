using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TuEntradaYa.Models.Dtos.Orders;
using TuEntradaYa.Models.Entities;
using TuEntradaYa.Services.Implementations;
using TuEntradaYa.Services.Interfaces;

namespace TuEntradaYa.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService) 
        { 
             _orderService = orderService;
        }


        [HttpPost("new-order")]
        [Authorize]
        public IActionResult CreateOrder([FromBody] OrderCreateDto orderDto)
        {
            bool addOrder = _orderService.CreateOrder(orderDto);
            if (!addOrder)
            {
                return Ok("La orden NO se ha creado");
            }
            return Ok("Se ha creado La orden" );
        }

        [HttpGet("all")]
        [Authorize(Policy = "Admin")]
        public ActionResult<List<Orders>> GetAllOrders()
        {
            var orders = _orderService.GetAllOrders();  
            return Ok(orders);
        }

        [HttpDelete("Delete-order")]
        [Authorize(Policy = "Admin")]
        public IActionResult DeleteOrder(int id)
        {
            bool orderIsDelete = _orderService.DeleteOrder(id);
            if (!orderIsDelete)
            {
                return Ok("La orden NO se ha eliminado");
            }

            return Ok("La orden se ha eliminado");
        }



    }
}
