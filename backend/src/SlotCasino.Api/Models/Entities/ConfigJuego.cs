using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SlotCasino.Api.Models.Entities
{
    [Table("config_juegos")]
    public class ConfigJuego
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("id_juego")]
        public Guid IdJuego { get; set; }
        
        [ForeignKey(nameof(IdJuego))]
        public Juego? Juego { get; set; }

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
