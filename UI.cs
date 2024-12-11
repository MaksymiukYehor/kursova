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

public class CommandManager
{
    private readonly List<ICommand> _commands;

    public CommandManager(IEnumerable<ICommand> commands)
    {
        _commands = commands.ToList();
    }

    public void ShowMenu()
    {
        Console.WriteLine("\nОберіть команду:");
        for (int i = 0; i < _commands.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_commands[i].Description}");
        }
        Console.WriteLine($"{_commands.Count + 1}. Вийти");
    }

    public void ExecuteCommand(int commandIndex)
    {
        if (commandIndex >= 1 && commandIndex <= _commands.Count)
        {
            _commands[commandIndex - 1].Execute();
        }
        else
        {
            Console.WriteLine("Невірна команда");
        }
    }
}

































/*

public class GameManager
{
    private readonly IGameService _gameService;
    private readonly IPlayerService _playerService;

    public GameManager(IGameService gameService, IPlayerService playerService)
    {
        _gameService = gameService;
        _playerService = playerService;
    }

    public void ShowMenu()
    {
        Console.WriteLine("Меню:");
        Console.WriteLine("1. Увійти в обліковий запис");
        Console.WriteLine("2. Зареєструватися");
        Console.WriteLine("3. Зіграти гру");
        Console.WriteLine("4. Ваш рейтинг");
        Console.WriteLine("5. Ваша історія");
        Console.WriteLine("6. Вийти");
    }

    public void ExecuteCommand(int choice)
    {
        switch (choice)
        {
            case 1:
                Login();
                break;
            case 2:
                Register();
                break;
            case 3:
                PlayGame();
                break;
            case 4:
                Rating();
                break;
            case 5:
                History();
                break;
            case 6:
                Console.WriteLine("Вихід з програми.");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Невірний вибір, спробуйте ще раз.");
                break;
        }
    }

    private void Login()
    {
        Console.Write("Введіть ім'я користувача: ");
        string username = Console.ReadLine();
        Console.Write("Введіть пароль: ");
        string password = Console.ReadLine();

        if (!_playerService.Login(username, password))
        {
            Console.WriteLine("Помилка входу. Перевірте ім'я користувача та пароль.");
        }
    }

    private void Register()
    {
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

    private void Rating()
    {
        var rating = _playerService.GetPlayerRating();
        Console.WriteLine("Ваш рейтинг:" + rating);
        
    }

    private void PlayGame()
    {
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

    private void History()
    {
        var games = _playerService.GetAccHistory();

        Console.WriteLine("Ваша історія ігор:");
        foreach (var game in games)
        {
            Console.WriteLine($"{game.id,-5} | {game.player.UserName,-15} | {game.type,-12} | {game.Rating,-7}");
        }
    }
}
*/