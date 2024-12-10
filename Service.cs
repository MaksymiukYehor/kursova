using Lab1;
using Factory;


public class PlayerService : IPlayerService
{
    private readonly IPlayerRepository _repository;
    private GameAccount _currentPlayer;

    public PlayerService(IPlayerRepository repository)
    {
        _repository = repository;
    }

    public void CreateAccount(GameAccount player)
    {
        if (_repository.Exists(player.Username))
        {
            throw new Exception("Користувач з таким іменем вже існує.");
        }

        _repository.CreateAcc(player);
    }

    /*
    public IEnumerable<GameAccount> GetAllAccounts()
    {
        return _repository.ReadAll();
    }
    */

    /*
    public GameAccount GetAccountById(string userName)
    {
        return _repository.ReadById(userName);
    }
    */

    public IEnumerable<Game> GetAccHistory(GameAccount player)
    {
        return _repository.GetAccHistory(userName);
    }

    public bool Register(string username, string password)
    {
        if (_repository.Exists(username))
        {
            throw new Exception("Користувач з таким логіном вже існує.");
        }

        _repository.Add(new Player(username, password));
        Console.WriteLine("Реєстрація успішна!");
        return true;
    }

    public bool Login(string username, string password)
    {
        var player = _repository.FindByUsername(username);

        if (player != null && player.Password == password)
        {
            _currentPlayer = player;
            Console.WriteLine($"Ласкаво просимо, {username}!");
            return true;
        }

        Console.WriteLine("Неправильний логін або пароль.");
        return false;
    }

    public void Logout()
    {
        _currentPlayer = null;
        Console.WriteLine("Ви вийшли з облікового запису.");
    }
}

public class GameService : IGameService
{
    private readonly IGameRepository _repository;

    public GameService(IGameRepository repository)
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

        Console.WriteLine($"Розпочато гру {type}. Ваша поточна оцінка: {currentPlayer.CurrentRating}");
        Console.WriteLine("Щоб завершити гру достроково, натисніть Ctrl + C.");

        while (true)
        {
            Console.Clear();
            DisplayBoard(game);
            Console.WriteLine($"Помилки: {errorCount}/{MaxErrors}");

            if (errorCount >= MaxErrors)
            {
                Console.WriteLine("Ви програли! Перевищено кількість помилок.");
                game.Result = false;
                _repository.PlayGame(type); // Запис гри
                currentPlayer.CurrentRating -= game.Rating;
                break;
            }

            if (IsBoardFull(game))
            {
                Console.WriteLine("Вітаємо! Ви завершили судоку.");
                game.Result = true;
                _repository.PlayGame(type); // Запис гри
                currentPlayer.CurrentRating += game.Rating;
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

                if (IsMoveValid(game, row, col, num))
                {
                    game.Board[row, col] = num;
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

    /*
    public IEnumerable<Game> GetAllGames()
    {
        return _repository.ReadAll();
    }
    */
    /*
    public Game GetGameById(int gameId)
    {
        return _repository.ReadById(gameId);
    }
    */
}
