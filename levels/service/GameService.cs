#pragma warning disable
using Lab1;
using Factory;

public class GameService : IGameService
{
    private readonly IGameRepository _repository;
    private readonly IPlayerService _playerService;

    public GameService(IGameRepository repository, IPlayerService playerService)
    {
        _repository = repository;
        _playerService = playerService;
    }

    public void PlayGame(string type, GameAccount currentPlayer)
    {
        if (currentPlayer == null)
        {
            Console.WriteLine("Будь ласка, увійдіть в обліковий запис перед початком гри.");
            return;
        }

        var game = GameFactory.CreateGame(type, currentPlayer);
        int errorCount = 0;
        const int MaxErrors = 5;

        game.FillBoard(0, 0);
        game.RemoveNumsFromBoard();

        while (true)
        {
            Console.Clear();

            Console.WriteLine($"Розпочато гру {type}. Ваша поточна оцінка: {currentPlayer.CurrentRating}");
            Console.WriteLine("Щоб завершити гру достроково, натисніть Ctrl + C.");

            Console.WriteLine("Поточна дошка:");
            game.DisplayBoard();
            Console.WriteLine($"Помилки: {errorCount}/{MaxErrors}");

            if (errorCount >= MaxErrors)
            {
                Console.WriteLine("Ви програли! Перевищено кількість помилок.");
                game.Result = false;
                currentPlayer.CalculateRating(game);
                _repository.PlayGame(game); // Запис гри
                
                break;
            }

            if (game.IsBoardFull())
            {
                Console.WriteLine("Вітаємо! Ви завершили судоку.");
                game.Result = true;
                currentPlayer.CalculateRating(game);
                _repository.PlayGame(game); // Запис гри
                break;
            }

            try
            {
                Console.Write("Введіть рядок (1-9): ");
                int row = int.Parse(Console.ReadLine()) - 1;

                Console.Write("Введіть стовпець (1-9): ");
                int col = int.Parse(Console.ReadLine()) - 1;

                Console.Write("Введіть число (1-9): ");
                int num = int.Parse(Console.ReadLine());

                if (game.IsMoveValid(row, col, num))
                {
                    game.board[row, col] = num;
                }
                else
                {
                    Console.WriteLine("Хід недійсний. Спробуйте знову.");
                    errorCount++;
                    Console.ReadKey();
                }
            }
            catch
            {
                Console.WriteLine("Помилка вводу. Спробуйте знову.");
                Console.ReadKey();
            }
        }
    }
 
    public IEnumerable<Game> GetAllGames()
    {
        return _repository.ReadAllGames();
    }
}
