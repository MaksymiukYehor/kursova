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