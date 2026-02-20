using Postgrest.Attributes;
using Postgrest.Models;

namespace SlotCasino.Api.Models.Supabase
{
    [Table("config_juegos")]
    public class ConfigJuego : BaseModel
    {
        [PrimaryKey("id")]
        public Guid Id { get; set; }

        [Column("id_juego")]
        public Guid IdJuego { get; set; }

        [Column("filas")]
        public int Filas { get; set; }

        [Column("columnas")]
        public int Columnas { get; set; }

        [Column("lineas_pago")]
        public int LineasPago { get; set; }

        [Column("color_tema")]
        public string? ColorTema { get; set; }

        [Column("simbolos")]
        public string[] Simbolos { get; set; } = Array.Empty<string>();

        [Column("actualizado_en")]
        public DateTime ActualizadoEn { get; set; }
    }
}
