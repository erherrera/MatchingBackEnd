using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace API.Controllers
{
    /// <summary>
    /// IdentificationController sirve para manejar las solicitudes de identificación de usuarios.
    /// </summary>

    [ApiController]
    [Route("[controller]")]

    public class IdentificationController : BaseApiController
    {
        private readonly IHttpClientFactory _httpClientFactory;

        /// <summary>
        /// IdentificationController es el constructor de la clase que recibe un IHttpClientFactory para crear instancias de HttpClient.
        /// </summary>
        /// <param name="httpClientFactory"></param>
        public IdentificationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

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
            var httpClient = _httpClientFactory.CreateClient();
            
            // Ignorar validación de certificados SSL (solo para desarrollo/testing)
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };
            
            using var client = new HttpClient(handler);
            
            try
            {
                // Hacer la petición GET al servicio externo
                var response = await client.GetAsync("https://10.19.151.100:443/status");
                
                // Leer el contenido como string sin deserializar
                var content = await response.Content.ReadAsStringAsync();
                
                // Retornar la respuesta tal cual con el status code original
                return new ContentResult
                {
                    Content = content,
                    ContentType = "application/json",
                    StatusCode = (int)response.StatusCode
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error al invocar el servicio externo", Error = ex.Message });
            }
        }
        /// <summary>
        /// Test get api
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetTestForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),

            })
            .ToArray();
        }
    }


    }
