using Microsoft.AspNetCore.Mvc;
using SlotCasino.Api.Services;

namespace SlotCasino.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BilleteraController : ControllerBase
    {
        private readonly IServicioBilletera _servicioBilletera;

        public BilleteraController(IServicioBilletera servicioBilletera)
        {
            _servicioBilletera = servicioBilletera;
        }

        [HttpGet("saldo/{idPerfil}")]
        public async Task<ActionResult<decimal>> GetSaldo(Guid idPerfil)
        {
            try
            {
                var saldo = await _servicioBilletera.ObtenerSaldoAsync(idPerfil);
                return Ok(new { saldo });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        [HttpPost("deposito")]
        public async Task<ActionResult> Depositar([FromBody] OperacionBilleteraRequest request)
        {
            try
            {
                var transaccion = await _servicioBilletera.RegistrarTransaccionAsync(request.IdPerfil, null, "deposit", request.Monto);
                return Ok(transaccion);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }
    }

    public class OperacionBilleteraRequest
    {
        public Guid IdPerfil { get; set; }
        public decimal Monto { get; set; }
    }
}
