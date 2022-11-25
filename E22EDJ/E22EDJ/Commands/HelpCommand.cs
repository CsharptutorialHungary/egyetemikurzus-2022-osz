using Spectre.Console;

namespace E22EDJ.Commands;

public class HelpCommand : IConsoleCommand
{
	public string Name => "help";
	public string Description => "Prints out all the available commands";

	public void Execute()
	{
		var loader = new CommandLoader();

		var commandList = loader.Commands;

		var table = new Table();

		
		table.AddColumn(new TableColumn("[green]Name[/]"));
		table.AddColumn(new TableColumn("[green]Description[/]"));
		
		foreach (var command in commandList)
		{
			table.AddRow(command.Value.Name, command.Value.Description);
		}

		AnsiConsole.Write(table);
	}
}