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
		
		List<Game> games = new();
		AnsiConsole
			.Status()
			.Spinner(Spinner.Known.CircleQuarters)
			.Start("Loading game list...", _ =>
			{
				games = _gameService.GetAllGames();
			});

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