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
		var games = _gameService.GetAllGames();

		while (true)
		{
			var selectedGame = GameConsoleCommandHelper.PromptUserToSelectGame(games, "[green]Which game do you want to delete?[/]");

			if (AnsiConsole.Confirm($"Are you sure you want to delete the game: [red]{selectedGame.Name}[/]?"))
			{
				_gameService.Delete(selectedGame.Id);
				break;
			}
			if (!AnsiConsole.Confirm($"Do you want to select another game?"))
			{
				break;
			}
		}
	}
	
}