using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SlotCasino.Api.Models.Entities
{
    [Table("transacciones")]
    public class Transaccion
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("id_perfil")]
        public Guid IdPerfil { get; set; }
        
        [ForeignKey(nameof(IdPerfil))]
        public Perfil? Perfil { get; set; }

        [Column("id_juego")]
        public Guid? IdJuego { get; set; }
        
        [ForeignKey(nameof(IdJuego))]
        public Juego? Juego { get; set; }

        [Column("tipo")]
        public string Tipo { get; set; } = string.Empty; // e.g., 'bet', 'win', 'deposit', 'withdraw'

        [Column("monto")]
        public decimal Monto { get; set; }

        [Column("saldo_despues")]
        public decimal SaldoDespues { get; set; }

        [Column("creado_en")]
        public DateTime CreadoEn { get; set; } = DateTime.UtcNow;
    }
}
