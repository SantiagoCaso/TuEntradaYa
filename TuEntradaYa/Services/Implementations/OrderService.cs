using TuEntradaYa.DBContext;
using TuEntradaYa.Services.Interfaces;

namespace TuEntradaYa.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly TuEntradaYaContext tuEntradaYaContext;

        public OrderService(TuEntradaYaContext tuEntradaYaContext)
        {
            this.tuEntradaYaContext = tuEntradaYaContext;
        }   


    }
}
