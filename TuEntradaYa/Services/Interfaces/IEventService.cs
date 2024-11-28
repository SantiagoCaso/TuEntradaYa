using TuEntradaYa.Models.Dtos.Events;
using TuEntradaYa.Models.Entities;

namespace TuEntradaYa.Services.Interfaces
{
    public interface IEventService
    {
        List<Events> GetAllEvents();
        bool AddEvent(EventCreateDto evento);

        bool DeleteEvent(int IdEvento);

        bool UpdateEvent(int eventId, EventUpdateDto evento);

        public Events? GetEventById(int id);

       
    }
}
