using Lab1;

// repo interface for game logic
public interface IGameRepository
{
    void PlayGame(Game game);
    IEnumerable<Game> ReadAllGames();
}