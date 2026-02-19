using System.ComponentModel.DataAnnotations;

namespace SlotCasino.Api.Models.DTOs
{
    public class PeticionTirada
    {
        [Required]
        public Guid IdPerfil { get; set; }

        [Required]
        public Guid IdJuego { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto de la apuesta debe ser mayor a 0.")]
        public decimal MontoApuesta { get; set; }
    }
}
