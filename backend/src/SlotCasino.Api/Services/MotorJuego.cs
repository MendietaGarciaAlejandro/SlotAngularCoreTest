using Microsoft.EntityFrameworkCore;
using SlotCasino.Api.Data;
using SlotCasino.Api.Models.DTOs;

namespace SlotCasino.Api.Services
{
    public class MotorJuego : IMotorJuego
    {
        private readonly CasinoDbContext _context;
        private readonly Random _random;

        public MotorJuego(CasinoDbContext context)
        {
            _context = context;
            _random = new Random();
        }

        public async Task<ResultadoTirada> CalcularTiradaAsync(Guid idJuego, decimal montoApuesta)
        {
            var config = await _context.ConfigJuegos
                .Include(c => c.Juego)
                .FirstOrDefaultAsync(c => c.IdJuego == idJuego);

            if (config == null || config.Juego == null)
                throw new Exception("Configuración de juego no encontrada.");

            // 1. Generar la cuadrícula (matriz) de resultados
            var cuadricula = GenerarCuadricula(config);

            // 2. Calcular premios basados en el RTP y volatilidad de forma simplificada
            // En un caso real, esto usaría la matemática exacta del slot (líneas de pago, peso de símbolos)
            var premio = CalcularPremio(config, montoApuesta, cuadricula);

            return new ResultadoTirada
            {
                Cuadricula = cuadricula,
                Premio = premio,
                LineasGanadoras = new List<LineaGanadora>() // Implementación detallada de líneas omitida por simplicidad
            };
        }

        private List<List<string>> GenerarCuadricula(Models.Entities.ConfigJuego config)
        {
            var grid = new List<List<string>>();
            var simbolosDisponibles = config.Simbolos;
            
            if (simbolosDisponibles == null || simbolosDisponibles.Length == 0)
            {
                 // Fallback si la DB no tiene símbolos
                 simbolosDisponibles = new[] { "🍒", "🍋", "🔔", "⭐", "💎", "7️⃣" };
            }

            for (int r = 0; r < config.Filas; r++)
            {
                var row = new List<string>();
                for (int c = 0; c < config.Columnas; c++)
                {
                    row.Add(simbolosDisponibles[_random.Next(simbolosDisponibles.Length)]);
                }
                grid.Add(row);
            }
            return grid;
        }

        private decimal CalcularPremio(Models.Entities.ConfigJuego config, decimal montoApuesta, List<List<string>> cuadricula)
        {
            // Lógica MUY simplificada de RNG basada en RTP
            // RTP (e.g. 96m = 96%) significa que estadísticamente devuelve el 96% de lo apostado a largo plazo.
            // Para la prueba, usamos una probabilidad directa de ganar vs perder.
            
            decimal rtp = config.Juego!.Rtp;
            
            // Probabilidad base de premio (no exacta matemáticamente, solo simulada)
            double probabilidadPremio = (double)rtp / 100.0 * 0.3; // 30% de las veces da ALGO, ajustado por RTP

            if (_random.NextDouble() < probabilidadPremio)
            {
                // Es un premio. Calculamos un multiplicador aleatorio
                // Con alta volatilidad, premios más raros pero más altos.
                double multiplicadorMinimo = 0.5;
                double multiplicadorMaximo = config.Juego.Volatilidad?.ToLower() == "high" ? 50.0 : 10.0;
                
                // Distribución para favorecer premios pequeños
                double factor = Math.Pow(_random.NextDouble(), 3); // Curva que favorece valores bajos
                decimal multiplicador = (decimal)(multiplicadorMinimo + (multiplicadorMaximo - multiplicadorMinimo) * factor);
                
                return Math.Round(montoApuesta * multiplicador, 2);
            }

            return 0m;
        }
    }
}
