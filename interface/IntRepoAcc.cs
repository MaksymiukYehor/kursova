using Lab1;

// Repo interface for accounts
public interface IPlayerRepository
{
    void CreateAcc(GameAccount player);
    IEnumerable<GameAccount> ReadAllAcc();
    bool Exists(string userName);
    GameAccount FindByUsername(string userName);
    IEnumerable<Game> GetAccHistory(string userName);
}