using Microsoft.EntityFrameworkCore;
using TuEntradaYa.DBContext;
using TuEntradaYa.Models.Dtos.Categories;
using TuEntradaYa.Models.Dtos.Tickets;
using TuEntradaYa.Models.Entities;
using TuEntradaYa.Services.Interfaces;

namespace TuEntradaYa.Services.Implementations
{
    public class TicketService : ITicketService
    {
        private readonly TuEntradaYaContext _tuEntradaYaContext;

        public TicketService(TuEntradaYaContext tuEntradaYaContext)
        {
            _tuEntradaYaContext = tuEntradaYaContext;
        }

        public bool AddTikets(CreateTicketDto ticket)
        {
            Tickets addTicket = new Tickets
            {
                EventId = ticket.EventId,
                CategoryId = ticket.CategoryId,
            };

            _tuEntradaYaContext.Tickets.Add(addTicket);
            _tuEntradaYaContext.SaveChanges();
            return true;
        }

        public List<Tickets> GetTickets()
        {
            var tickets = _tuEntradaYaContext.Tickets.Include(e => e.Event).Include(c => c.Category).ToList(); 
            return tickets;
        }
    }
}
