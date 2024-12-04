using Microsoft.EntityFrameworkCore;
using TuEntradaYa.DBContext;
using TuEntradaYa.Models.Entities;
using TuEntradaYa.Services.Interfaces;

namespace TuEntradaYa.Services.Implementations
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly TuEntradaYaContext _tuEntradaYaContext;

        public OrderDetailService(TuEntradaYaContext tuEntradaYaContext)
        {
            _tuEntradaYaContext = tuEntradaYaContext;
        }

        public List<OrdersDetail> GetOrdersDetails()
        {
            var ordersDetails = _tuEntradaYaContext.OrdersDetail.Include(u => u.User).Include(o => o.Orders).ToList();  
            return ordersDetails;
        }
            
    }
}
