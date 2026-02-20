using Microsoft.AspNetCore.Mvc;
using SlotCasino.Api.Models.DTOs;
using SlotCasino.Api.Models.Supabase;

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
        public async Task<ActionResult<List<JuegoDTO>>> GetJuegos()
        {
            var response = await _supabase.From<Juego>().Get();
            var list = new List<JuegoDTO>();
            foreach (var j in response.Models)
            {
                list.Add(new JuegoDTO {
                    Id = j.Id,
                    Titulo = j.Titulo,
                    Proveedor = j.Proveedor,
                    UrlMiniatura = j.UrlMiniatura,
                    Rtp = j.Rtp,
                    Volatilidad = j.Volatilidad,
                    EsDestacado = j.EsDestacado,
                    Descripcion = j.Descripcion,
                    CreadoEn = j.CreadoEn
                });
            }
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JuegoDTO>> GetJuego(Guid id)
        {
            var response = await _supabase.From<Juego>()
                .Where(j => j.Id == id)
                .Single();
            
            if (response == null) return NotFound();
            
            return Ok(new JuegoDTO {
                Id = response.Id,
                Titulo = response.Titulo,
                Proveedor = response.Proveedor,
                UrlMiniatura = response.UrlMiniatura,
                Rtp = response.Rtp,
                Volatilidad = response.Volatilidad,
                EsDestacado = response.EsDestacado,
                Descripcion = response.Descripcion,
                CreadoEn = response.CreadoEn
            });
        }

        [HttpGet("destacados")]
        public async Task<ActionResult<List<JuegoDTO>>> GetJuegosDestacados()
        {
            var response = await _supabase.From<Juego>()
                .Where(j => j.EsDestacado == true)
                .Get();
                
            var list = new List<JuegoDTO>();
            foreach (var j in response.Models)
            {
                list.Add(new JuegoDTO {
                    Id = j.Id,
                    Titulo = j.Titulo,
                    Proveedor = j.Proveedor,
                    UrlMiniatura = j.UrlMiniatura,
                    Rtp = j.Rtp,
                    Volatilidad = j.Volatilidad,
                    EsDestacado = j.EsDestacado,
                    Descripcion = j.Descripcion,
                    CreadoEn = j.CreadoEn
                });
            }
            return Ok(list);
        }

        [HttpGet("{id}/config")]
        public async Task<ActionResult<ConfigJuegoDTO>> GetConfigJuego(Guid id)
        {
            var response = await _supabase.From<ConfigJuego>()
                .Where(c => c.IdJuego == id)
                .Single();
                
            if (response == null) return NotFound("Configuración no encontrada para este juego.");
            
            return Ok(new ConfigJuegoDTO
            {
                Id = response.Id,
                IdJuego = response.IdJuego,
                Filas = response.Filas,
                Columnas = response.Columnas,
                LineasPago = response.LineasPago,
                ColorTema = response.ColorTema,
                Simbolos = response.Simbolos,
                ActualizadoEn = response.ActualizadoEn
            });
        }
    }
}

