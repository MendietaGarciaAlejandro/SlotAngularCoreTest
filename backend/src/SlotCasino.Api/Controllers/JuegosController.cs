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
        public async Task<ActionResult<IEnumerable<JuegoDTO>>> GetJuegos()
        {
            var response = await _supabase.From<Juego>().Get();
            var dtos = response.Models.Select(j => MapToDTO(j)).ToList();
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JuegoDTO>> GetJuego(Guid id)
        {
            var response = await _supabase.From<Juego>()
                .Where(j => j.Id == id)
                .Single();
            
            if (response == null) return NotFound();
            return Ok(MapToDTO(response));
        }

        [HttpGet("destacados")]
        public async Task<ActionResult<IEnumerable<JuegoDTO>>> GetJuegosDestacados()
        {
            var response = await _supabase.From<Juego>()
                .Where(j => j.EsDestacado == true)
                .Get();
                
            var dtos = response.Models.Select(j => MapToDTO(j)).ToList();
            return Ok(dtos);
        }

        [HttpGet("{id}/config")]
        public async Task<ActionResult<ConfigJuegoDTO>> GetConfigJuego(Guid id)
        {
            var response = await _supabase.From<ConfigJuego>()
                .Where(c => c.IdJuego == id)
                .Single();
                
            if (response == null) return NotFound("Configuración no encontrada para este juego.");
            
            return Ok(new ConfigJuegoDTO(
                response.Id, response.IdJuego, response.Filas, response.Columnas, 
                response.LineasPago, response.ColorTema, response.Simbolos, response.ActualizadoEn
            ));
        }

        private static JuegoDTO MapToDTO(Juego j) => new JuegoDTO(
            j.Id, j.Titulo, j.Proveedor, j.UrlMiniatura, j.Rtp, j.Volatilidad, j.EsDestacado, j.Descripcion, j.CreadoEn
        );
    }

    public record JuegoDTO(Guid Id, string Titulo, string Proveedor, string? UrlMiniatura, 
        decimal Rtp, string? Volatilidad, bool EsDestacado, string? Descripcion, DateTime CreadoEn);
        
    public record ConfigJuegoDTO(Guid Id, Guid IdJuego, int Filas, int Columnas, 
        int LineasPago, string? ColorTema, string[] Simbolos, DateTime ActualizadoEn);
}

