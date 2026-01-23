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

    [HttpGet("featured")]
    public ActionResult<IEnumerable<Game>> GetFeaturedGames()
    {
        var featuredGames = MockGames.FindAll(g => g.IsFeatured);
        return Ok(featuredGames);
    }

    [HttpGet("provider/{provider}")]
        public ActionResult<IEnumerable<Game>> GetGamesByProvider(string provider)
    {
        var gamesByProvider = MockGames.FindAll(g => g.Provider.Equals(provider, StringComparison.OrdinalIgnoreCase));
        return Ok(gamesByProvider);
    }

    [HttpGet("search/{query}")]
    public ActionResult<IEnumerable<Game>> SearchGames(string query)
    {
        var matchedGames = MockGames.FindAll(g => g.Title.Contains(query, StringComparison.OrdinalIgnoreCase));
        return Ok(matchedGames);
    }

    [HttpGet("stats")]
    public ActionResult<object> GetGameStats()
    {
        var totalGames = MockGames.Count;
        var averageRtp = MockGames.Count > 0 ? MockGames.Average(g => g.Rtp) : 0;
        var volatilityDistribution = new Dictionary<string, int>
        {
            ["Low"] = MockGames.Count(g => g.Volatility == "Low"),
            ["Medium"] = MockGames.Count(g => g.Volatility == "Medium"),
            ["High"] = MockGames.Count(g => g.Volatility == "High")
        };
        var stats = new
        {
            TotalGames = totalGames,
            AverageRtp = Math.Round(averageRtp, 2),
            VolatilityDistribution = volatilityDistribution
        };
        return Ok(stats);
    }

    [HttpGet("themes/{color}")]
    public ActionResult<IEnumerable<Game>> GetGamesByThemeColor(string color)
    {
        var gamesByColor = MockConfigs
            .Where(kv => kv.Value.ThemeColor.Equals($"#{color}", StringComparison.OrdinalIgnoreCase))
            .Select(kv => MockGames.Find(g => g.Id == kv.Key))
            .Where(g => g != null)
            .ToList();
        return Ok(gamesByColor);
    }

    [HttpGet("rtp/{min}/{max}")]
    public ActionResult<IEnumerable<Game>> GetGamesByRtpRange(double min, double max)
    {
        var gamesInRange = MockGames.FindAll(g => g.Rtp >= min && g.Rtp <= max);
        return Ok(gamesInRange);
    }

    [HttpGet("volatility/{level}")]
    public ActionResult<IEnumerable<Game>> GetGamesByVolatility(string level)
    {
        var gamesByVolatility = MockGames.FindAll(g => g.Volatility.Equals(level, StringComparison.OrdinalIgnoreCase));
        return Ok(gamesByVolatility);
    }

    [HttpGet("random")]
    public ActionResult<Game> GetRandomGame()
    {
        var random = new Random();
        var randomGame = MockGames[random.Next(MockGames.Count)];
        return Ok(randomGame);
    }
}
