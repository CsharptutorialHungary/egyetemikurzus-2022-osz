using E22EDJ.DBModels;
using E22EDJ.Services;
using Spectre.Console;

namespace E22EDJ.Commands.GameRelated;

public class DeleteGameCommand : IConsoleCommand
{
	public string Name => "delete_game";
	public string Description => "Remove a game form your library";
	
	private readonly GameService _gameService = new();
	public void Execute()
	{
		List<Game?> games;
		try
		{
			games = _gameService.GetNotCompletedGames();
		}
		catch (Exception)
		{
			AnsiConsole.Write(new Markup("[red]Error getting games from the database[/] \n"));
			return;
		}

		while (true)
		{
			var selectedGame = GameConsoleCommandHelper.PromptUserToSelectGame(games, "[green]Which game do you want to delete?[/]");

			if (AnsiConsole.Confirm($"Are you sure you want to delete the game: [red]{selectedGame.Name}[/]?"))
			{
				try
				{
					_gameService.Delete(selectedGame.Id);
					AnsiConsole.Write(new Markup("[green]Successfully deleted the game[/] \n"));
				}
				catch (Exception )
				{
					AnsiConsole.Write(new Markup("[red]Error deleting the game from the database[/] \n"));
				}
				break;
			}
			if (!AnsiConsole.Confirm($"Do you want to select another game?"))
			{
				break;
			}
		}
	}
	
}