using Microsoft.AspNetCore.Mvc;
using SlotCasino.Api.Models.DTOs;
using SlotCasino.Api.Services;

namespace SlotCasino.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TiradasController : ControllerBase
    {
        private readonly IMotorJuego _motorJuego;
        private readonly IServicioBilletera _servicioBilletera;

        public TiradasController(IMotorJuego motorJuego, IServicioBilletera servicioBilletera)
        {
            _motorJuego = motorJuego;
            _servicioBilletera = servicioBilletera;
        }

        [HttpPost("jugar")]
        public async Task<ActionResult<ResultadoTirada>> Jugar([FromBody] PeticionTirada peticion)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                // 1. Cobrar la apuesta (esto validará si hay saldo en el servicio)
                await _servicioBilletera.RegistrarTransaccionAsync(peticion.IdPerfil, peticion.IdJuego, "bet", peticion.MontoApuesta);

                // 2. Calcular el resultado de la tirada
                var resultado = await _motorJuego.CalcularTiradaAsync(peticion.IdJuego, peticion.MontoApuesta);

                // 3. Pagar el premio si hubo ganancia
                if (resultado.EsPremio)
                {
                    await _servicioBilletera.RegistrarTransaccionAsync(peticion.IdPerfil, peticion.IdJuego, "win", resultado.Premio);
                }

                // 4. Obtener saldo final para devolver al cliente
                resultado.NuevoSaldo = await _servicioBilletera.ObtenerSaldoAsync(peticion.IdPerfil);

                return Ok(resultado);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { mensaje = "Saldo insuficiente para realizar la apuesta.", detalle = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Ocurrió un error al procesar la tirada.", detalle = ex.Message });
            }
        }
    }
}
