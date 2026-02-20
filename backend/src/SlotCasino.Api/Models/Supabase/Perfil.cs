using Postgrest.Attributes;
using Postgrest.Models;

namespace SlotCasino.Api.Models.Supabase
{
    [Table("perfiles")]
    public class Perfil : BaseModel
    {
        [PrimaryKey("id")]
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
