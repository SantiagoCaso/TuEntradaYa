using TuEntradaYa.Models.Entities;

namespace TuEntradaYa.Services.Interfaces
{
    public interface ITicketService
    {
        List<Tickets> GetTickets();

        bool AddTikets();
    }
}
