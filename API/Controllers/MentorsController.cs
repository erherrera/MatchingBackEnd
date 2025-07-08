using Application;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    /// <summary>
    /// Manages Mentor operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MentorController(IMediator mediator) : BaseApiController
    {
        /// <summary>
        /// Checks if the Mentor API is working.
        /// This endpoint is used to verify that the Mentor API is operational.
        /// </summary>
        /// <returns></returns>
        /*[HttpGet]
        public IActionResult Get()
        {
            return Ok("Mentor API is working");
        }*/

        /// <summary>
        /// Retrieves a list of mentors.
        /// This endpoint returns a list of all mentors available in the system.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Mentor>>> GetMentorsList()
        {
            return await mediator.Send(new GetMentorList.Query());
        }

        /// <summary>
        /// Retrieves details of a specific mentor by ID.
        /// This endpoint returns detailed information about a mentor specified by their ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Mentor>> GetMentorDetail(string id)
        {
            return await mediator.Send(new GetMentorDetails.Query { Id = id });
        }


    }
}
