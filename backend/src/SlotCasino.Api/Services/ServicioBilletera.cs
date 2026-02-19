using Microsoft.EntityFrameworkCore;
using SlotCasino.Api.Data;
using SlotCasino.Api.Models.Entities;

namespace SlotCasino.Api.Services
{
    public class ServicioBilletera : IServicioBilletera
    {
        private readonly CasinoDbContext _context;

        public ServicioBilletera(CasinoDbContext context)
        {
            _context = context;
        }

        public async Task<Perfil?> ObtenerPerfilAsync(Guid idPerfil)
        {
            return await _context.Perfiles.FindAsync(idPerfil);
        }

        public async Task<decimal> ObtenerSaldoAsync(Guid idPerfil)
        {
            var perfil = await ObtenerPerfilAsync(idPerfil);
            return perfil?.Saldo ?? 0;
        }

        public async Task<Transaccion> RegistrarTransaccionAsync(Guid idPerfil, Guid? idJuego, string tipo, decimal monto)
        {
            var perfil = await ObtenerPerfilAsync(idPerfil);
            if (perfil == null) throw new Exception("Perfil no encontrado.");

            // Validar saldo para apuestas/retiros
            if ((tipo == "bet" || tipo == "withdraw") && perfil.Saldo < monto)
            {
                throw new InvalidOperationException("Saldo insuficiente.");
            }

            // Actualizar saldo (restar si es bet/withdraw, sumar si es win/deposit)
            if (tipo == "bet" || tipo == "withdraw")
            {
                perfil.Saldo -= monto;
            }
            else if (tipo == "win" || tipo == "deposit")
            {
                perfil.Saldo += monto;
            }

            perfil.ActualizadoEn = DateTime.UtcNow;

            var transaccion = new Transaccion
            {
                IdPerfil = idPerfil,
                IdJuego = idJuego,
                Tipo = tipo,
                Monto = monto,
                SaldoDespues = perfil.Saldo,
                CreadoEn = DateTime.UtcNow
            };

            _context.Transacciones.Add(transaccion);
            await _context.SaveChangesAsync();

            return transaccion;
        }
    }
}
