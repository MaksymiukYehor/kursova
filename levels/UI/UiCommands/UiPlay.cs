#pragma warning disable
using Lab1;

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