using Postgrest.Attributes;
using Postgrest.Models;

namespace SlotCasino.Api.Models.Supabase
{
    [Table("transacciones")]
    public class Transaccion : BaseModel
    {
        [PrimaryKey("id")]
        public Guid Id { get; set; }

        [Column("id_perfil")]
        public Guid IdPerfil { get; set; }

        [Column("id_juego")]
        public Guid? IdJuego { get; set; }

        [Column("tipo")]
        public string Tipo { get; set; } = string.Empty;

        [Column("monto")]
        public decimal Monto { get; set; }

        [Column("saldo_despues")]
        public decimal SaldoDespues { get; set; }

        [Column("creado_en")]
        public DateTime CreadoEn { get; set; } = DateTime.UtcNow;
    }
}
