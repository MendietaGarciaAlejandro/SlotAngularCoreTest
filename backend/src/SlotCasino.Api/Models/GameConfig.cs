namespace SlotCasino.Api.Models;

public class GameConfig
{
    public string GameId { get; set; } = string.Empty;
    public List<string> Symbols { get; set; } = new();
    public int Rows { get; set; }
    public int Cols { get; set; }
    public int Paylines { get; set; }
    public string ThemeColor { get; set; } = "#444";
}
