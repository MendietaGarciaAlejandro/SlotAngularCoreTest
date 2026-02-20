namespace SlotCasino.Api.Models.DTOs
{
    public class JuegoDTO
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Proveedor { get; set; } = string.Empty;
        public string? UrlMiniatura { get; set; }
        public decimal Rtp { get; set; }
        public string? Volatilidad { get; set; }
        public bool EsDestacado { get; set; }
        public string? Descripcion { get; set; }
        public DateTime CreadoEn { get; set; }
    }
}
