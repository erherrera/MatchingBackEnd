using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// IdentificationController sirve para manejar las solicitudes de identificación de usuarios.
    /// </summary>

    [ApiController]
    [Route("[controller]")]

    public class IdentificationController : BaseApiController
    {
        /// <summary>
        /// Identify es un método que recibe una solicitud de identificación y devuelve una respuesta con los servicios asociados al número de teléfono proporcionado.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType<IdentifyResponse>(StatusCodes.Status200OK)]
        public async Task<IActionResult> Identify(
            [FromBody] IdentifyRequest request)
        {
            return Ok();


        }
    }
}
