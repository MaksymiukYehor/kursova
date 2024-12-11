#pragma warning disable
using Lab1;

public class PlayerRepository : IPlayerRepository
{
    private readonly DbContext _dbContext;

    public PlayerRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void CreateAcc(GameAccount player)
    {
        _dbContext.Players.Add(player);
    }
    
    public IEnumerable<GameAccount> ReadAllAcc()
    {
        return _dbContext.Players;
    }

    public GameAccount ReadByName(string userName)
    {
        return _dbContext.Players.Find(account => account.UserName == userName);
    }
    
    public void UpdateRating(GameAccount player)
    {
        var existingPlayer = ReadByName(player.UserName);
        if (existingPlayer != null)
        {
            existingPlayer.CurrentRating = player.CurrentRating;
        }
    }

    public void Delete(string userName)
    {
        var player = ReadByName(userName);
        if (player != null)
        {
            _dbContext.Players.Remove(player);
        }
    }

    public IEnumerable<Game> GetAccHistory(string userName)
    {
        return _dbContext.Games.Where(g => g.player.UserName == userName);
    }

    public bool Exists(string userName)
    {
        return _dbContext.Players.Any (p => p.UserName == userName);
    }

    public GameAccount FindByUsername(string userName)
    {
        return _dbContext.Players.FirstOrDefault (p => p.UserName == userName);
    }
}

public class GameRepository : IGameRepository
{
    private readonly DbContext _dbContext;

    public GameRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void PlayGame(Game game)
    {
        _dbContext.Games.Add(game);
    }

    public IEnumerable<Game> ReadAllGames()
    {
        return _dbContext.Games;
    }

    public Game ReadGameById(int id)
    {
        return _dbContext.Games.Find(g => g.id == id);
    }

    public void Update(Game game)
    {
        var existingGame = ReadGameById(game.id);
        if (existingGame != null)
        {
            existingGame.Rating = game.Rating;
        }
    }

    public void Delete(int gameId)
    {
        var game = ReadGameById(gameId);
        if (game != null)
        {
            _dbContext.Games.Remove(game);
        }
    }

}
