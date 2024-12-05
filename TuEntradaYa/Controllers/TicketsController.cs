using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TuEntradaYa.Models.Dtos.Tickets;
using TuEntradaYa.Models.Entities;
using TuEntradaYa.Services.Interfaces;

namespace TuEntradaYa.Controllers
{
    [ApiController]
    [Route("api/tickets")]
    public class TicketsController : Controller
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost("add-ticket")]
        [Authorize(Policy = "Admin")]
        public ActionResult AddTikets([FromBody] CreateTicketDto ticket)
        {
            bool addTiket = _ticketService.AddTikets(ticket);
            return Ok("Se agrego el ticket");
        }

        [HttpGet]
        public ActionResult GetTikets() 
        {
            return Ok(_ticketService.GetTickets());
        }


        [HttpGet("{eventId}")]
        public ActionResult<List<Tickets>> GetTicketsByEventId(int eventId) 
        {
            var tickets = _ticketService.GetTicketsByEventId(eventId);
            if (!tickets.Any())
            {
                return Ok("El evento no tiene entradas disponibles" );
            }
            return Ok(tickets); 
        }

        [HttpGet("total-tickes-by-event/{eventId}")]
        public ActionResult<int> GetTicketsSumByEventId(int eventId)
        {
            var sum = _ticketService.GetTicketsSumByEventId(eventId);
            if (sum == 0)
            {
                return Ok("El evento no tiene entradas disponibles");
            }
            return Ok("Total de entradas de evento: " + sum);
        }

    }
}
