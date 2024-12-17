using Lab1;

//service interface for accounts
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