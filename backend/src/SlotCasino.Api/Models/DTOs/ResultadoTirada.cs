namespace SlotCasino.Api.Models.DTOs
{
    public class ResultadoTirada
    {
        public List<List<string>> Cuadricula { get; set; } = new();
        public decimal Premio { get; set; }
        public List<LineaGanadora> LineasGanadoras { get; set; } = new();
        public bool EsPremio => Premio > 0;
        public decimal NuevoSaldo { get; set; }
    }

    public class LineaGanadora
    {
        public List<int[]> Posiciones { get; set; } = new(); // Arreglos de [Fila, Columna]
        public string Simbolo { get; set; } = string.Empty;
        public decimal Multiplicador { get; set; }
    }
}
