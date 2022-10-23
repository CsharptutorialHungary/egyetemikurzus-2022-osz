namespace E22EDJ.Commands;

public class HelloWorldCommand : IConsoleCommand
{
	public string Name => "HelloWorld";
	public string Description => "Prints hello world";

	public void Execute()
	{
		Console.WriteLine("Hello World!");
	}
}