using SlotCasino.Api.Models.Supabase;

namespace SlotCasino.Api.Services
{
    public interface IServicioBilletera
    {
        Task<Perfil?> ObtenerPerfilAsync(Guid idPerfil);
        Task<decimal> ObtenerSaldoAsync(Guid idPerfil);
        Task<Transaccion> RegistrarTransaccionAsync(Guid idPerfil, Guid? idJuego, string tipo, decimal monto);
    }
}
