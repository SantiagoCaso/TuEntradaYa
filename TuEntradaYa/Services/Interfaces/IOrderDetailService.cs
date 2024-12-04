using TuEntradaYa.DBContext;
using TuEntradaYa.Models.Dtos.OrdersDetails;
using TuEntradaYa.Models.Entities;

namespace TuEntradaYa.Services.Interfaces
{
    public interface IOrderDetailService
    {
        List<OrdersDetail> GetOrdersDetails();

    //    bool CreateOrderDetail(CreateOrderDetailDto orderDetail);
    }
}
