using Lab1;

//  service interface for game logic 
public interface IGameService
{
    void PlayGame(string type, GameAccount currentPlayer);
    IEnumerable<Game> GetAllGames();
}
