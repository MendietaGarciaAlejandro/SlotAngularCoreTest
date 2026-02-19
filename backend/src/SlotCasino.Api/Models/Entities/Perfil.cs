using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SlotCasino.Api.Models.Entities
{
    [Table("perfiles")]
    public class Perfil
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("nombre_usuario")]
        public string NombreUsuario { get; set; } = string.Empty;

        [Column("saldo")]
        public decimal Saldo { get; set; } = 0.0m;

        [Column("creado_en")]
        public DateTime CreadoEn { get; set; } = DateTime.UtcNow;

        [Column("actualizado_en")]
        public DateTime ActualizadoEn { get; set; } = DateTime.UtcNow;
    }
}
