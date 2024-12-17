#pragma warning disable
using Lab1;

public class RegisterCommand : ICommand
{
    private readonly IPlayerService _playerService;

    public RegisterCommand(IPlayerService playerService)
    {
        _playerService = playerService;
    }

    public void Execute()
    {
        Console.Clear();
        Console.Write("Введіть нове ім'я користувача: ");
        string username = Console.ReadLine();
        Console.Write("Введіть новий пароль: ");
        string password = Console.ReadLine();

        try
        {
            _playerService.Register(username, password);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка реєстрації: {ex.Message}");
        }
    }

    public string Description => "Регістрація";
}

public class LoginCommand : ICommand
{
    private readonly IPlayerService _playerService;

    public LoginCommand(IPlayerService playerService)
    {
        _playerService = playerService;
    }

    public void Execute()
    {
        Console.Clear();
        Console.Write("Введіть ім'я користувача: ");
        string username = Console.ReadLine();
        Console.Write("Введіть пароль: ");
        string password = Console.ReadLine();

        if (!_playerService.Login(username, password))
        {
            Console.WriteLine("Помилка входу. Перевірте ім'я користувача та пароль.");
        }
    }

    public string Description => "Увійти";
}

public class LogOutCommand : ICommand
{
    private readonly IPlayerService _playerService;

    public LogOutCommand(IPlayerService playerService)
    {
        _playerService = playerService;
    }

    public void Execute()
    {
        Console.Clear();
        if (_playerService.Logout())
        {
            Console.WriteLine("Ви вийшли з облікового запису.");
        }
        else
        {
        Console.WriteLine("Вхід не виконаний.");
        }
    }

    public string Description => "Вийти з аккаунту";
}

public class PlayCommand : ICommand
{
    private readonly IGameService _gameService;
    private readonly IPlayerService _playerService;

    public PlayCommand(IGameService gameService, IPlayerService playerService)
    {
        _gameService = gameService;
        _playerService = playerService;
    }

    public void Execute()
    {
        Console.Clear();
        var currentPlayer = _playerService.GetCurrentPlayer();
        if (currentPlayer == null)
        {
            Console.WriteLine("Спочатку увійдіть в обліковий запис.");
            return;
        }

        Console.WriteLine("Виберіть рівень складності (Easy/Hard/Test):");
        string difficulty = Console.ReadLine();

        _gameService.PlayGame(difficulty, currentPlayer);
    }

    public string Description => "Почати гру";
}

public class RatingCommand : ICommand
{
    private readonly IPlayerService _playerService;

    public RatingCommand(IPlayerService playerService)
    {
        _playerService = playerService;
    }

    public void Execute()
    {
        Console.Clear();
        var rating = _playerService.GetPlayerRating();
        if (rating == -1)
        {
            Console.WriteLine("Спочатку увійдіть в обліковий запис.");
        }
        else
        {
            Console.WriteLine("Ваш рейтинг:" + rating);
        }
    }

    public string Description => "Ваш рейтинг";
}

public class HistoryCommand : ICommand
{
    private readonly IPlayerService _playerService;

    public HistoryCommand(IPlayerService playerService)
    {
        _playerService = playerService;
    }

    public void Execute()
    {
        Console.Clear();
        var games = _playerService.GetAccHistory();
        Console.WriteLine("Історія ігор:");
        Console.WriteLine($"{"ID Гри",-7} | {"Результат",-12} | {"Тип гри",-12} |{"Ставка",-7}");
        foreach (var game in games)
        {
            Console.WriteLine($"{game.id,-7} | {(game.Result ? "Перемога" : "Поразка"),-12} | {game.type,-12} |{game.Rating,-7}");
        } 
    }

    public string Description => "Ваша історія";
}

public class AllGamesCommand : ICommand
{
    private readonly IGameService _GameService;

    public AllGamesCommand(IGameService GameService)
    {
        _GameService = GameService;
    }

    public void Execute()
    {
        Console.Clear();
        var games = _GameService.GetAllGames();

        Console.WriteLine("Всі створені ігри з БД:");
        Console.WriteLine($"{"ID Гри",-7} | {"Гравець",-15} | {"Результат",-12} | {"Тип гри",-12} |{"Ставкв",-7}");
        foreach (var game in games)
        {
            Console.WriteLine($"{game.id,-7} | {game.player.UserName,-15} | {(game.Result ? "Перемога" : "Поразка"),-12} | {game.type,-12} |{game.Rating,-7}");
        }
    }

    public string Description => "Вивести ігри з БД";
}

public class AllAccCommand : ICommand
{
    private readonly IPlayerService _playerService;

    public AllAccCommand(IPlayerService playerService)
    {
        _playerService = playerService;
    }

    public void Execute()
    {
        Console.Clear();
        var players = _playerService.GetAllAccounts();

        Console.WriteLine("Всі створені ігри з БД:");
        foreach (var player in players)
        {
            Console.WriteLine($"{player.UserName,-15}");
        }
    }

    public string Description => "Вивести гравців з БД";
}

