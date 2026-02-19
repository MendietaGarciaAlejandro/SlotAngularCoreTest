using SlotCasino.Api.Models.DTOs;

namespace SlotCasino.Api.Services
{
    public interface IMotorJuego
    {
        Task<ResultadoTirada> CalcularTiradaAsync(Guid idJuego, decimal montoApuesta);
    }
}
