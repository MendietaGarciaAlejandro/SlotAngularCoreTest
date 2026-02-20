using SlotCasino.Api.Models.DTOs;
using SlotCasino.Api.Models.Supabase;

namespace SlotCasino.Api.Services
{
    public class MotorJuego : IMotorJuego
    {
        private readonly Supabase.Client _supabase;
        private readonly Random _random;

        public MotorJuego(Supabase.Client supabase)
        {
            _supabase = supabase;
            _random = new Random();
        }

        public async Task<ResultadoTirada> CalcularTiradaAsync(Guid idJuego, decimal montoApuesta)
        {
            var config = await _supabase.From<ConfigJuego>()
                .Where(c => c.IdJuego == idJuego)
                .Single();

            var juego = await _supabase.From<Juego>()
                .Where(j => j.Id == idJuego)
                .Single();

            if (config == null || juego == null)
                throw new Exception("Configuración de juego no encontrada.");

            var cuadricula = GenerarCuadricula(config);
            var premio = CalcularPremio(juego, config, montoApuesta, cuadricula);

            return new ResultadoTirada
            {
                Cuadricula = cuadricula,
                Premio = premio,
                LineasGanadoras = new List<LineaGanadora>()
            };
        }

        private List<List<string>> GenerarCuadricula(ConfigJuego config)
        {
            var grid = new List<List<string>>();
            var simbolosDisponibles = config.Simbolos;

            if (simbolosDisponibles == null || simbolosDisponibles.Length == 0)
                simbolosDisponibles = new[] { "🍒", "🍋", "🔔", "⭐", "💎", "7️⃣" };

            for (int r = 0; r < config.Filas; r++)
            {
                var row = new List<string>();
                for (int c = 0; c < config.Columnas; c++)
                    row.Add(simbolosDisponibles[_random.Next(simbolosDisponibles.Length)]);
                grid.Add(row);
            }
            return grid;
        }

        private decimal CalcularPremio(Juego juego, ConfigJuego config, decimal montoApuesta, List<List<string>> cuadricula)
        {
            decimal rtp = juego.Rtp;
            double probabilidadPremio = (double)rtp / 100.0 * 0.3;

            if (_random.NextDouble() < probabilidadPremio)
            {
                double multiplicadorMinimo = 0.5;
                double multiplicadorMaximo = juego.Volatilidad?.ToLower() == "alta" ? 50.0 : 10.0;
                double factor = Math.Pow(_random.NextDouble(), 3);
                decimal multiplicador = (decimal)(multiplicadorMinimo + (multiplicadorMaximo - multiplicadorMinimo) * factor);
                return Math.Round(montoApuesta * multiplicador, 2);
            }

            return 0m;
        }
    }
}
