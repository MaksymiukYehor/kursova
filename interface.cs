using Lab1;

//service interface
public interface IPlayerService
{
    void CreateAccount(GameAccount player);
    bool Register(string userName, string password);
    bool Login(string userName, string password);
    void Logout();    
    //IEnumerable<GameAccount> GetAllAccounts();

    //GameAccount GetAccountById(string userName);

    IEnumerable<Game> GetAccHistory(GameAccount player);
}

public interface IGameService
{
    void PlayGame(string type, GameAccount currentPlayer);

    //IEnumerable<Game> GetAllGames();

    //Game GetGameById(int gameId);
}


//repo interface
public interface IPlayerRepository
{
    void CreateAcc(GameAccount player);

    //IEnumerable<GameAccount> ReadAll();
    //GameAccount ReadById(string userName);
    //void Update(GameAccount player);
    //void Delete(string userName);
    IEnumerable<Game> GetAccHistory(string userName);
    bool Exists(string userName);
    GameAccount FindByUsername(string userName);
}

public interface IGameRepository
{
    void PlayGame(string type);

    //IEnumerable<Game> ReadAll();

    //Game ReadById(int id);

    void Update(Game game);
    void Delete(int id);
}

public interface ICommand
{
    void Execute();
    string Description { get; }
}
