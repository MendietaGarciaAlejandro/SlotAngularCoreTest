using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SlotCasino.Api.Data;
using SlotCasino.Api.Models.Entities;

namespace SlotCasino.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JuegosController : ControllerBase
    {
        private readonly CasinoDbContext _context;

        public JuegosController(CasinoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Juego>>> GetJuegos()
        {
            var juegos = await _context.Juegos.ToListAsync();
            return Ok(juegos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Juego>> GetJuego(Guid id)
        {
            var juego = await _context.Juegos.FindAsync(id);
            if (juego == null) return NotFound();
            return Ok(juego);
        }

        [HttpGet("destacados")]
        public async Task<ActionResult<IEnumerable<Juego>>> GetJuegosDestacados()
        {
            var destacados = await _context.Juegos.Where(j => j.EsDestacado).ToListAsync();
            return Ok(destacados);
        }

        [HttpGet("{id}/config")]
        public async Task<ActionResult<ConfigJuego>> GetConfigJuego(Guid id)
        {
            var config = await _context.ConfigJuegos.FirstOrDefaultAsync(c => c.IdJuego == id);
            if (config == null) return NotFound("Configuración no encontrada para este juego.");
            return Ok(config);
        }
    }
}
