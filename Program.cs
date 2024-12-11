using System;
using Lab1;
class Program

{
    static void Main()
    {
        var dbContext = new DbContext();
        var playerRepository = new PlayerRepository(dbContext);
        var gameRepository = new GameRepository(dbContext);

        var playerService = new PlayerService(playerRepository);
        var gameService = new GameService(gameRepository, playerService);

        var commands = new List<ICommand>
        {
            new RegisterCommand(playerService),            
            new LoginCommand(playerService),
            new PlayCommand(gameService, playerService),
            new RatingCommand(playerService),
            new HistoryCommand(playerService),
            new AllGamesCommand(gameService),
            new AllAccCommand(playerService),
            new LogOutCommand(playerService),
        };

        var commandManager = new CommandManager(commands);

        while (true)
        {
            commandManager.ShowMenu();
            if (int.TryParse(Console.ReadLine(), out int choice) && choice == commands.Count + 1)
            {
                break;
            }

            commandManager.ExecuteCommand(choice);
        }
    }
}
