#pragma warning disable
using Lab1;

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
}