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
    /*
    public IEnumerable<GameAccount> ReadAll()
    {
        return _dbContext.Players;
    }

    public GameAccount ReadById(string userName)
    {
        return _dbContext.Players.Find(account => account.UserName == userName);
    }
    */
    /*
    public void Update(GameAccount player)
    {
        var existingPlayer = ReadById(player.UserName);
        if (existingPlayer != null)
        {
            existingPlayer.CurrentRating = player.CurrentRating;
        }
    }

    public void Delete(string userName)
    {
        var player = ReadById(userName);
        if (player != null)
        {
            _dbContext.Players.Remove(player);
        }
    }
    */

    public IEnumerable<Game> GetAccHistory(string userName)
    {
        return _dbContext.Games.Where(g => g.Winner.UserName == userName || g.Loser.UserName == userName);
    }

    public bool Exists(string userName)
    {
        return Players.Any (p => p.UserName == userName);
    }

    public GameAccount FindByUsername(string userName)
    {
        return Players.FirstOrDefault (p => p.UserName == userName);
    }
}

public class GameRepository : IGameRepository
{
    private readonly DbContext _dbContext;

    public GameRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void PlayGame(string type)
    {
        

        _dbContext.Games.Add(game);
    }

    public IEnumerable<Game> ReadAll()
    {
        return _dbContext.Games;
    }

    public Game ReadById(int gameId)
    {
        return _dbContext.Games.Find(g => g.GameID == gameId);
    }

    public void Update(Game game)
    {
        var existingGame = ReadById(game.GameID);
        if (existingGame != null)
        {
            existingGame.Rating = game.Rating;
        }
    }

    public void Delete(int gameId)
    {
        var game = ReadById(gameId);
        if (game != null)
        {
            _dbContext.Games.Remove(game);
        }
    }
}
