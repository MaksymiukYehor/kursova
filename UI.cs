public class PlayGameCommand : ICommand
{
    private readonly IGameService _gameService;
    private readonly IPlayerService _playerService;

    public PlayGameCommand(IGameService gameService, IPlayerService playerService)
    {
        _gameService = gameService;
        _playerService = playerService;
    }

    public string Description => "Зіграти гру";

    public void Execute()
    {
        Console.WriteLine("Виберіть рівень складності (Easy/Hard):");
        string difficulty = Console.ReadLine();

        Console.WriteLine("Введіть ім'я користувача:");
        string username = Console.ReadLine();

        var player = _playerService.Login(username, ""); // Уявно аутентифікуємо для тестів
        if (player != null)
        {
            _gameService.PlayGame(difficulty, player);
        }
        else
        {
            Console.WriteLine("Гравця не знайдено.");
        }
    }
}

public class ShowPlayersCommand : ICommand
{
    private readonly IPlayerService _playerService;

    public ShowPlayersCommand(IPlayerService playerService)
    {
        _playerService = playerService;
    }

    public string Description => "Показати всіх гравців";

    public void Execute()
    {
        Console.WriteLine("Список гравців:");
        foreach (var player in _playerService.GetAllAccounts())
        {
            Console.WriteLine($"{player.UserName} - Рейтинг: {player.CurrentRating}");
        }
    }
}
