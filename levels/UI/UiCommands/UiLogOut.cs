#pragma warning disable
using Lab1;

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