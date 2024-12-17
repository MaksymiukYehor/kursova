#pragma warning disable
using Lab1;

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