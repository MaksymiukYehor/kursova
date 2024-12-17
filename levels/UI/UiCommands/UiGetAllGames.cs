#pragma warning disable
using Lab1;

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