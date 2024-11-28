using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TuEntradaYa.Models.Dtos.Events;
using TuEntradaYa.Models.Entities;
using TuEntradaYa.Services.Interfaces;

namespace TuEntradaYa.Controllers
{
    [ApiController]
    [Route("api/events")]
    public class EventController : Controller
    {

        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet("all-events")]
        public List<Events> GetAllEvents()
        {
            var allevents = _eventService.GetAllEvents();
            return allevents;
        }

        [HttpPost("add-event")]
        // si pongo [Authorize] me pone que no se encuentra referencia de para la autorizacion o algo así 

        public IActionResult AddEvent([FromBody] EventCreateDto evento)
        {
            bool addEvent = _eventService.AddEvent(evento);
            return Ok("Se ha creado el evento: " + evento.Event);
        }

        [HttpDelete("delete-event")]
        // Poner [Authorize] 
        public IActionResult DeleteEvent(int IdEvento)
        {
            bool eventDelete = _eventService.DeleteEvent(IdEvento);
            return Ok("El evento se ha eliminado");
        }

        [HttpPut("update-event/{id}")]
        // Poner [Authorize] 

        public IActionResult UpdateEvent(int id, [FromBody] EventUpdateDto evento)
        {

            bool eventToUpdate = _eventService.UpdateEvent(id, evento);
            return Ok("Evento Actualizado: " + evento.Event);   
        }

        [HttpGet("{id}")]
        public Events ? GetEventById(int id)
        {
            return _eventService.GetEventById(id);
        }
    }
}
