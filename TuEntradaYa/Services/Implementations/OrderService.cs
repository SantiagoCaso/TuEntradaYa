using Microsoft.EntityFrameworkCore;
using TuEntradaYa.DBContext;
using TuEntradaYa.Models.Dtos.Orders;
using TuEntradaYa.Models.Entities;
using TuEntradaYa.Services.Interfaces;

namespace TuEntradaYa.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly TuEntradaYaContext _tuEntradaYaContext;
        private readonly IUserService _userService;

        public OrderService(TuEntradaYaContext tuEntradaYaContext, IUserService userService)
        {
            _tuEntradaYaContext = tuEntradaYaContext;
            _userService = userService;
        }

        public List<Orders> GetAllOrders()
        {
            var orders = _tuEntradaYaContext.Orders.Include(u => u.Users)
                .Include(t => t.Tickets).ThenInclude(e => e.Event)
                .Include(t => t.Tickets).ThenInclude(e => e.Category)
                .ToList();
            return orders;
        }

        public bool CreateOrder(OrderCreateDto orderDto)
        {

            bool TicketSold = _tuEntradaYaContext.Orders.Any(o => o.TicketId == orderDto.TicketId);

            if (TicketSold)
            {
                
                return false;
            }

            var ticket = _tuEntradaYaContext.Tickets.FirstOrDefault(t => t.Id == orderDto.TicketId);

            var order = new Orders
            {
                UserId = orderDto.UserId,
                CreateAt = orderDto.CreateAt,
                TicketId = orderDto.TicketId,
                Total = ticket.Price + 778 // recargo por servicio 
            };

            _tuEntradaYaContext.Orders.Add(order);
            _tuEntradaYaContext.SaveChanges();
            return true;
        }

        public bool DeleteOrder(int orderId)
        {
            Orders ? orderToDelete = _tuEntradaYaContext.Orders.FirstOrDefault(o => o.Id == orderId);
            if (orderToDelete == null)
            {
                return false;
            }

            _tuEntradaYaContext.Orders.Remove(orderToDelete);
            _tuEntradaYaContext.SaveChanges();
            return true;
        }

        public List<Orders> GetOrderByUserName(string email, string password, string userName) 
        {
            Users? userLogIn = _userService.Authenticate(email, password);

            if (userLogIn == null )
            {
                throw new UnauthorizedAccessException("Credenciales incorrectas: No se encontró un usuario con el email y contraseña proporcionados");
            }

            var orders = _tuEntradaYaContext.Orders.Include(u => u.Users)
                .Include(t => t.Tickets).ThenInclude(e => e.Event)
                .Include(t => t.Tickets).ThenInclude(e => e.Category)
                .Where(u => u.Users.Name == userName).ToList();
            return orders;  
        }


    }
}
