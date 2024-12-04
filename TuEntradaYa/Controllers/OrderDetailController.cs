using Microsoft.AspNetCore.Mvc;
using TuEntradaYa.Models.Entities;
using TuEntradaYa.Services.Interfaces;

namespace TuEntradaYa.Controllers
{
    [ApiController]
    [Route("api/orders-detail")]
    public class OrderDetailController : Controller
    {
        private readonly IOrderDetailService _orderDetailService;   

        public OrderDetailController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        [HttpGet("all")]   
        public List<OrdersDetail> GetOrdersDetails()
        {
            return _orderDetailService.GetOrdersDetails();
        }
    }

}
