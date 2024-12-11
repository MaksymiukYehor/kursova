using Lab1;

//service interface
public interface IPlayerService
{
    bool Register(string userName, string password);
    bool Login(string userName, string password);
    bool Logout();    
    GameAccount GetCurrentPlayer();
    int GetPlayerRating();
    IEnumerable<GameAccount> GetAllAccounts();
    IEnumerable<Game> GetAccHistory();
}

public interface IGameService
{
    void PlayGame(string type, GameAccount currentPlayer);
    IEnumerable<Game> GetAllGames();
}

//repo interface
public interface IPlayerRepository
{
    void CreateAcc(GameAccount player);
    IEnumerable<GameAccount> ReadAllAcc();
    void UpdateRating(GameAccount player);
    void Delete(string userName);
    bool Exists(string userName);
    GameAccount FindByUsername(string userName);
    GameAccount ReadByName(string userName);
    IEnumerable<Game> GetAccHistory(string userName);
}

public interface IGameRepository
{
    void PlayGame(Game game);
    IEnumerable<Game> ReadAllGames();
    Game ReadGameById(int id);
    void Update(Game game);
    void Delete(int id);

}

//UI interface
public interface ICommand
{
    void Execute();
    string Description { get; }
}
