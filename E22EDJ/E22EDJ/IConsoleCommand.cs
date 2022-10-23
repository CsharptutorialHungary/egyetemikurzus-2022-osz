namespace E22EDJ;

public interface IConsoleCommand
{
    string Name { get; }
    void Execute();
}