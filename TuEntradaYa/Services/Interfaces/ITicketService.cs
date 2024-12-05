using TuEntradaYa.DBContext;
using TuEntradaYa.Models.Dtos.Categories;
using TuEntradaYa.Models.Dtos.Tickets;
using TuEntradaYa.Models.Entities;

namespace TuEntradaYa.Services.Interfaces
{
    public interface ITicketService
    {
        List<Tickets> GetTickets();

        bool AddTikets(CreateTicketDto ticket);

        List<Tickets> GetTicketsByEventName(string eventName);

        List<Tickets> GetTicketsByEventId(int eventId);

        int GetTicketsSumByEventId(int eventId);


    }
}
