using Application;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MentorController(IMediator mediator) : BaseApiController
    {
        // GET: api/mentor
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Mentor API is working");
        }

        // GET: api/mentor
        [HttpGet]
        public async Task<ActionResult<List<Mentor>>> GetMentorsList()
        {
            return await mediator.Send(new GetMentorList.Query());
        }

        // GET: api/mentor/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Mentor>> GetMentorDetail(string id)
        {
            return await mediator.Send(new GetMentorDetails.Query { Id = id });
        }


    }
}
