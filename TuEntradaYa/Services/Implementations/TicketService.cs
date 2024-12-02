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

        public List<Tickets> GetTicketsByEventName(string eventName)
        {
            var tickets = _tuEntradaYaContext.Tickets.Include(e => e.Event).Include(c => c.Category).Where(t => t.Event != null && t.Event.Event == eventName).ToList();
            return tickets;
        }

        public List<Tickets> GetTicketsByEventId(int eventId)
        {
            var tickets = _tuEntradaYaContext.Tickets.Include(t => t.Event).Include(c => c.Category).Where(e => e.EventId == eventId).ToList();
            return tickets;
        }
        public int GetTicketsSumByEventId(int eventId)
        {
            var tickets = _tuEntradaYaContext.Tickets.Count(e => e.EventId == eventId);
            return tickets;
        }

    }
}

