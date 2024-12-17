#pragma warning disable
using Lab1;

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