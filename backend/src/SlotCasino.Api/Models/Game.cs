namespace SlotCasino.Api.Models;

public class Game
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Provider { get; set; } = string.Empty;
    public string ThumbnailUrl { get; set; } = string.Empty;
    public double Rtp { get; set; }
    public string Volatility { get; set; } = "Medium";
    public bool IsFeatured { get; set; }
    public string Description { get; set; } = string.Empty;
}
