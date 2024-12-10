using System;
using System.Collections.Generic;
using Lab1;

class Program
{
    static void Main(string[] args)
    {
        // Ініціалізація бази даних
        var dbContext = new DbContext();

        // Ініціалізація репозиторіїв
        var playerRepository = new PlayerRepository(dbContext);
        var gameRepository = new GameRepository(dbContext);

        // Ініціалізація сервісів
        var playerService = new PlayerService(playerRepository);
        var gameService = new GameService(gameRepository, playerService);

        // Список команд
        var commands = new List<ICommand>
        {
            new ShowPlayersCommand(playerService),         // Показати гравців
            new AddPlayerCommand(playerService),           // Додати нового гравця
            new ShowPlayerStatsCommand(playerService),     // Показати статистику гравця
            new PlayGameCommand(gameService, playerService), // Зіграти гру
            new ShowAllGamesCommand(gameService)           // Показати всі ігри
        };

        var commandManager = new CommandManager(commands);

        // Основний цикл програми
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Меню ===");
            commandManager.ShowMenu();

            Console.WriteLine("Введіть номер опції (або 0 для виходу): ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice == 0)
            {
                Console.WriteLine("Вихід з програми...");
                break;
            }

            try
            {
                commandManager.ExecuteCommand(choice);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }
    }
}
