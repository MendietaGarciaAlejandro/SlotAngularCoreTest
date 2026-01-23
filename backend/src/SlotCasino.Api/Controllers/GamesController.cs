using Microsoft.AspNetCore.Mvc;
using SlotCasino.Api.Models;

namespace SlotCasino.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GamesController : ControllerBase
{
    private static readonly List<Game> MockGames = new()
    {
        new Game { Id = "1", Title = "Sweet Bonanza", Provider = "Pragmatic Play", ThumbnailUrl = "https://placehold.co/300x200/FF5733/FFF?text=Sweet+Bonanza", Rtp = 96.48, Volatility = "High", IsFeatured = true, Description = "¡Disfruta de dulces victorias!" },
        new Game { Id = "2", Title = "Book of Dead", Provider = "Play'n GO", ThumbnailUrl = "https://placehold.co/300x200/C70039/FFF?text=Book+of+Dead", Rtp = 96.21, Volatility = "High", IsFeatured = true, Description = "Explora el antiguo Egipto." },
        new Game { Id = "3", Title = "Starburst", Provider = "NetEnt", ThumbnailUrl = "https://placehold.co/300x200/900C3F/FFF?text=Starburst", Rtp = 96.09, Volatility = "Low", IsFeatured = false, Description = "Clásico arcade espacial." }
    };

    private static readonly Dictionary<string, GameConfig> MockConfigs = new()
    {
        ["1"] = new GameConfig { GameId = "1", Symbols = new() { "🍭", "🍇", "🍉", "🍌", "🍎" }, Rows = 5, Cols = 6, Paylines = 0, ThemeColor = "#ff69b4" },
        ["2"] = new GameConfig { GameId = "2", Symbols = new() { "🏺", "🐕", "🦅", "🤠" }, Rows = 3, Cols = 5, Paylines = 10, ThemeColor = "#d4af37" },
        ["default"] = new GameConfig { GameId = "0", Symbols = new() { "🍒", "🍋", "🔔", "7️⃣" }, Rows = 3, Cols = 5, Paylines = 20, ThemeColor = "#ff0000" }
    };

    [HttpGet]
    public ActionResult<IEnumerable<Game>> GetGames()
    {
        return Ok(MockGames);
    }

    [HttpGet("{id}")]
    public ActionResult<Game> GetGame(string id)
    {
        var game = MockGames.Find(g => g.Id == id);
        if (game == null) return NotFound();
        return Ok(game);
    }

    [HttpGet("{id}/config")]
    public ActionResult<GameConfig> GetConfig(string id)
    {
        if (MockConfigs.TryGetValue(id, out var config))
        {
            return Ok(config);
        }
        return Ok(MockConfigs["default"]);
    }
}
