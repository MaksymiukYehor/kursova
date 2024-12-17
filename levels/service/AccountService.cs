#pragma warning disable
using Lab1;
using Factory;

public class PlayerService : IPlayerService
{
    private readonly IPlayerRepository _repository;
    private GameAccount _currentPlayer;

    public PlayerService(IPlayerRepository repository)
    {
        _repository = repository;
    }
    
    public IEnumerable<GameAccount> GetAllAccounts()
    {
        return _repository.ReadAllAcc();
    }
    
    public bool Register(string username, string password)
    {
        if (_repository.Exists(username))
        {
            Console.WriteLine("Користувач з таким логіном вже існує.");
        }

        _repository.CreateAcc(new GameAccount(username, password));
        Console.WriteLine("Реєстрація успішна!");
        return true;
    }

    public bool Login(string username, string password)
    {
        var player = _repository.FindByUsername(username);

        if (player != null && player.Password == password)
        {
            _currentPlayer = player;
            Console.WriteLine($"Ласкаво просимо, {username}!");
            return true;
        }

        Console.WriteLine("Неправильний логін або пароль.");
        return false;
    }

    public bool Logout()
    {
        if (_currentPlayer == null)
        {
            return false;
        }
        else
        {
            _currentPlayer = null;
            return true;
        }
    }
    
    public GameAccount GetCurrentPlayer()
    {
        return _currentPlayer;
    }

    public int GetPlayerRating()
    {
        if (_currentPlayer != null)
        {
            return _currentPlayer.CurrentRating;
        }
        else
        {
            return -1;
        }
    }

    public IEnumerable<Game> GetAccHistory()
    {
        if (_currentPlayer != null)
        {
            var PlayerNameHistory = _currentPlayer.UserName;
            return _repository.GetAccHistory(PlayerNameHistory);
        }
        else
        {
            return Enumerable.Empty<Game>();
        }
    }
}