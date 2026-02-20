using Microsoft.AspNetCore.Mvc;
using SlotCasino.Api.Models.Entities;

namespace SlotCasino.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JuegosController : ControllerBase
    {
        private readonly Supabase.Client _supabase;

        public JuegosController(Supabase.Client supabase)
        {
            _supabase = supabase;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Juego>>> GetJuegos()
        {
            var response = await _supabase.From<Juego>().Get();
            return Ok(response.Models);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Juego>> GetJuego(Guid id)
        {
            var response = await _supabase.From<Juego>()
                .Where(j => j.Id == id)
                .Single();
            if (response == null) return NotFound();
            return Ok(response);
        }

        [HttpGet("destacados")]
        public async Task<ActionResult<IEnumerable<Juego>>> GetJuegosDestacados()
        {
            var response = await _supabase.From<Juego>()
                .Where(j => j.EsDestacado == true)
                .Get();
            return Ok(response.Models);
        }

        [HttpGet("{id}/config")]
        public async Task<ActionResult<ConfigJuego>> GetConfigJuego(Guid id)
        {
            var response = await _supabase.From<ConfigJuego>()
                .Where(c => c.IdJuego == id)
                .Single();
            if (response == null) return NotFound("Configuración no encontrada para este juego.");
            return Ok(response);
        }
    }
}
