using E22EDJ.DBModels;
using E22EDJ.Services;
using Spectre.Console;

namespace E22EDJ.Commands.GameRelated;

public class GetGamesCommand : IConsoleCommand
{
	
	public string Name => "get_games";
	public string Description => "Returns a list of games";

	private readonly GameService _gameService = new();
	public void Execute()
	{
		
		List<Game?> games = new();
		try
		{
			AnsiConsole
				.Status()
				.Spinner(Spinner.Known.CircleQuarters)
				.Start("Loading game list...", _ =>
				{
					try
					{
						games = _gameService.GetAllGames();
					}
					catch (Exception e)
					{
						AnsiConsole.Write(new Markup("[red]Error getting games from the database[/] \n"));
						throw;
					}
				});
		}
		catch (Exception e)
		{
			return;
		}
		

		var table = new Table();

		table.AddColumn(new TableColumn("[bold green]Title[/]"));
		table.AddColumn(new TableColumn("[bold green]Time Spent[/]"));
		table.AddColumn(new TableColumn("[bold green]State[/]"));
		
		foreach (var game in games)
		{
			table.AddRow(game.Name, game.TimeSpent.ToString(), game.GameState.Name);
		}
		
		AnsiConsole.Write(table);
		
	}
}