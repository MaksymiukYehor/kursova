#pragma warning disable
using Lab1;

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