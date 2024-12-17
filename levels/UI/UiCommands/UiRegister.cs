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