using Lab1;

//UI interface
public interface ICommand
{
    void Execute();
    string Description { get; }
}