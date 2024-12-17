#pragma warning disable
using Lab1;

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