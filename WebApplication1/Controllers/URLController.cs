using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;

using UrlShorter.Data;

using UrlShorter.Services;

namespace UrlShorter.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    [Authorize]


    public class URLController : ControllerBase
    {
        private readonly URLShortContext _context;
        private readonly URLServices _services;
        public URLController(URLShortContext context, URLServices services)
        {
            _context = context;
            _services = services;
        }

        [HttpPost]
        public IActionResult POSTURL([FromBody] string URLUser, [FromQuery] string? Categoria)
        {

            int IdUser = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);



            if (URLUser.Length > 6) //codigo para ver si es mayor a 6 digitos
            {
                if (_context.Urls.Any(u => u.UrlLong == URLUser))    //codigo para ver si esta en la base de datos
                {

                    int contador = _services.SumarContador(URLUser);
                    return Ok(contador);

                }
                else
                {

                    string ShortURL = _services.CrearShortUrl(URLUser);
                    _services.GuardarURL(URLUser, ShortURL, Categoria, IdUser);

                    return Ok(ShortURL);
                }

            }
            else
            {
                if (_context.Urls.Any(u => u.UrlShort == URLUser))
                {
                    string URLLong = _services.GetURLLongForShort(URLUser);
                    int contador = _services.SumarContador(URLUser);
                    return Ok(URLLong);
                }
                else return BadRequest("La URL no se encuentra en la  base de datos.");
            }


        }

        [HttpGet]

        public IActionResult GetURL()
        {
            return Ok(_context.Urls.ToList());
        }


        [HttpGet("Urls-por-Usuario")]
        public IActionResult GetURLporUsuario()
        {
            int IdUser = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);



            return Ok(_services.GetUrlsPorUsuario(IdUser));
        }


        [HttpPut("Free-URL")]
        [AllowAnonymous]

        public IActionResult FreeURL([FromBody] string URL)
        {


            int? IdUser = int.TryParse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value, out var userId) ? userId : (int?)null;
            if (IdUser.HasValue)
            {

                return Ok(POSTURL(URL, "Sin Categoria")
);
            }
            else
            {
                if (_context.Urls.Any(u => u.UrlShort == URL))
                {
                    string URLLong = _services.GetURLLongForShort(URL);
                    int contador = _services.SumarContador(URL);
                    return Ok(URLLong);
                }
                else return BadRequest("La URL no se encuentra en la  base de datos.");
            }


        }
    }
}
