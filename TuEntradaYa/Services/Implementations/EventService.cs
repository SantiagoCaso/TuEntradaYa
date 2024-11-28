using System.ComponentModel;
using TuEntradaYa.DBContext;
using TuEntradaYa.Models.Dtos.Events;
using TuEntradaYa.Models.Entities;
using TuEntradaYa.Services.Interfaces;

namespace TuEntradaYa.Services.Implementations
{
    public class EventService : IEventService
    {
       
        private readonly TuEntradaYaContext _tuEntradaYaContext;

        public EventService( TuEntradaYaContext tuEntradaYaContext) 
        { 
            
            _tuEntradaYaContext = tuEntradaYaContext;
        }   

        public List<Events> GetAllEvents()
        {
            return _tuEntradaYaContext.Events.ToList(); 
        }

        public bool AddEvent(EventCreateDto newEvent)
        {
            bool eventExist = _tuEntradaYaContext.Events.Any(e => e.Event == newEvent.Event && e.EventDate == newEvent.EventDate);

            Events addEvent = new Events
            {
                Event = newEvent.Event,
                NumberTikets = newEvent.NumberTikets,
                EventPlace = newEvent.EventPlace,
                EventDate = newEvent.EventDate,
                EventDescription = newEvent.EventDescription
            };

            _tuEntradaYaContext.Events.Add(addEvent);
            _tuEntradaYaContext.SaveChanges();
            return true;

        }

        public bool DeleteEvent(int  id)
        {
            Events ? deleteToEvent = _tuEntradaYaContext.Events.FirstOrDefault(e => e.Id == id);

            if (deleteToEvent == null)
            {
                Console.WriteLine("El evento no se encuentra ");
                return true;
            }

            _tuEntradaYaContext.Events.Remove(deleteToEvent);
            _tuEntradaYaContext.SaveChanges();
            return true;
        }

        public bool UpdateEvent(int eventId, EventUpdateDto evento) 
        {
            Events ? updateEvent = _tuEntradaYaContext.Events.FirstOrDefault(e => e.Id == eventId);

            updateEvent.Event = evento.Event;
            updateEvent.NumberTikets = evento.NumberTikets;
            updateEvent.EventPlace = evento.EventPlace; 
            updateEvent.EventDescription = evento.EventDescription;

            _tuEntradaYaContext.SaveChanges();
            return true;
        }

        public Events? GetEventById(int id)
        {
            Events ? evento = _tuEntradaYaContext.Events.FirstOrDefault(e => e.Id == id);
            return evento;

        }

    }
}
