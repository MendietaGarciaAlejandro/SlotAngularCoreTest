using SlotCasino.Api.Models.Entities;

namespace SlotCasino.Api.Services
{
    public class ServicioBilletera : IServicioBilletera
    {
        private readonly Supabase.Client _supabase;

        public ServicioBilletera(Supabase.Client supabase)
        {
            _supabase = supabase;
        }

        public async Task<Perfil?> ObtenerPerfilAsync(Guid idPerfil)
        {
            return await _supabase.From<Perfil>()
                .Where(p => p.Id == idPerfil)
                .Single();
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
                throw new InvalidOperationException("Saldo insuficiente.");

            // Actualizar saldo
            if (tipo == "bet" || tipo == "withdraw")
                perfil.Saldo -= monto;
            else if (tipo == "win" || tipo == "deposit")
                perfil.Saldo += monto;

            perfil.ActualizadoEn = DateTime.UtcNow;
            await _supabase.From<Perfil>().Upsert(perfil);

            var transaccion = new Transaccion
            {
                Id = Guid.NewGuid(),
                IdPerfil = idPerfil,
                IdJuego = idJuego,
                Tipo = tipo,
                Monto = monto,
                SaldoDespues = perfil.Saldo,
                CreadoEn = DateTime.UtcNow
            };

            await _supabase.From<Transaccion>().Insert(transaccion);

            return transaccion;
        }
    }
}
