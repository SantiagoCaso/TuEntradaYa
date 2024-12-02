using Microsoft.AspNetCore.Mvc;
using TuEntradaYa.Models.Dtos.Tickets;
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
    }
}
