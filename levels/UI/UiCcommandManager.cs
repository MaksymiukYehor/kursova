#pragma warning disable
using Lab1;

public class CommandManager
{
    private readonly List<ICommand> _commands;

    public CommandManager(IEnumerable<ICommand> commands)
    {
        _commands = commands.ToList();
    }

    public void ShowMenu()
    {
        Console.WriteLine("\nОберіть команду:");
        for (int i = 0; i < _commands.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_commands[i].Description}");
        }
        Console.WriteLine($"{_commands.Count + 1}. Вийти");
    }

    public void ExecuteCommand(int commandIndex)
    {
        if (commandIndex >= 1 && commandIndex <= _commands.Count)
        {
            _commands[commandIndex - 1].Execute();
        }
        else
        {
            Console.WriteLine("Невірна команда");
        }
    }
}