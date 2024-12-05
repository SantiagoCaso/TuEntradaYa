using TuEntradaYa.Models.Dtos.Orders;
using TuEntradaYa.Models.Entities;

namespace TuEntradaYa.Services.Interfaces
{
    public interface IOrderService
    {
        List<Orders> GetAllOrders();

        bool CreateOrder(OrderCreateDto orderDto);

        bool DeleteOrder(int orderId);

    }
}
