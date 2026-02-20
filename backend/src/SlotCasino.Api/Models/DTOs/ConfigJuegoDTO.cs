namespace SlotCasino.Api.Models.DTOs
{
    public class ConfigJuegoDTO
    {
        public Guid Id { get; set; }
        public Guid IdJuego { get; set; }
        public int Filas { get; set; }
        public int Columnas { get; set; }
        public int LineasPago { get; set; }
        public string? ColorTema { get; set; }
        public string[] Simbolos { get; set; } = Array.Empty<string>();
        public DateTime ActualizadoEn { get; set; }
    }
}
