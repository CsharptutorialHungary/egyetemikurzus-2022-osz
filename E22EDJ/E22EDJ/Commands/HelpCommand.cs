namespace E22EDJ.Commands;

public class HelpCommand : IConsoleCommand
{
	public string Name => "help";
	public string Description => "Prints out all the available commands";

	public void Execute()
	{
		var loader = new CommandLoader();

		var commandList = loader.Commands;
		Console.WriteLine("-------------");
		foreach (var command in commandList)
		{
			Console.WriteLine($"{command.Value.Name} : {command.Value.Description}");
		}
		Console.WriteLine("-------------");
	}
}