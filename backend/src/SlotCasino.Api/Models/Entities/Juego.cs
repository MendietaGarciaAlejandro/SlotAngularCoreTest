using Postgrest.Attributes;
using Postgrest.Models;

namespace SlotCasino.Api.Models.Entities
{
    [Table("juegos")]
    public class Juego : BaseModel
    {
        [PrimaryKey("id")]
        public Guid Id { get; set; }

        [Column("titulo")]
        public string Titulo { get; set; } = string.Empty;

        [Column("proveedor")]
        public string Proveedor { get; set; } = string.Empty;

        [Column("url_miniatura")]
        public string? UrlMiniatura { get; set; }

        [Column("rtp")]
        public decimal Rtp { get; set; }

        [Column("volatilidad")]
        public string? Volatilidad { get; set; }

        [Column("es_destacado")]
        public bool EsDestacado { get; set; }

        [Column("descripcion")]
        public string? Descripcion { get; set; }

        [Column("creado_en")]
        public DateTime CreadoEn { get; set; }
    }
}
