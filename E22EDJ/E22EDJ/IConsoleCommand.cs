namespace E22EDJ;

public interface IConsoleCommand
{
	string Name { get; }
	string Description { get; }
	void Execute();
}