using E22EDJ.AppModels;
using E22EDJ.DBModels;
using E22EDJ.Services;
using Spectre.Console;

namespace E22EDJ.Commands.GameRelated;

public class ChangeGameStateCommand : IConsoleCommand
{
	public string Name => "change_game_state";
	public string Description => "Change the state of a game you are playing";
	
	private readonly GameService _gameService = new();
	private readonly GameStateService _gameStateService = new();
	public void Execute()
	{
		List<Game?> games;
		List<GameState> gameStates;

		try
		{
			games = _gameService.GetAllGames();
		}
		catch (Exception)
		{
			AnsiConsole.Write(new Markup("[red]Error getting games from the database[/] \n"));
			return;
		}

		try
		{
			gameStates = _gameStateService.GetAllGameStates();
		}
		catch (Exception)
		{
			AnsiConsole.Write(new Markup("[red]Error game states from the database[/] \n"));
			return;
		}

		while (true)
		{
			var selectedGame = GameConsoleCommandHelper.PromptUserToSelectGame(games);
			var selectedState = GameStateConsoleCommandHelper.PromptUserToSelectGameState(gameStates);
			
			if (AnsiConsole.Confirm($"Are you sure you want to change the state of game: [red]{selectedGame!.Name}[/] from [red]{selectedGame.GameState.Name}[/] to [red]{selectedState.Name}[/]?"))
			{
				try
				{
					_gameService.Update(selectedGame.Id, new UpdateGame(gameStateId: selectedState.Id));
					AnsiConsole.Write(new Markup("[green]Successfully updated game in database[/] \n"));
				}
				catch (Exception)
				{
					AnsiConsole.Write(new Markup("[red]Error updating the game database[/] \n"));
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