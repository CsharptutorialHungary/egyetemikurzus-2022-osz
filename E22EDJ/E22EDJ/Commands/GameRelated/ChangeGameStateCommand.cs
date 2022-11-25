using E22EDJ.AppModels;
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
		var games = _gameService.GetAllGames();
		var gameStates = _gameStateService.GetAllGameStates();

		while (true)
		{
			var selectedGame = GameConsoleCommandHelper.PromptUserToSelectGame(games);
			var selectedState = GameStateConsoleCommandHelper.PromptUserToSelectGameState(gameStates);
			
			if (AnsiConsole.Confirm($"Are you sure you want to change the state of game: [red]{selectedGame.Name}[/] from [red]{selectedGame.GameState.Name}[/] to [red]{selectedState.Name}[/]?"))
			{
				_gameService.Update(selectedGame.Id, new UpdateGame(gameStateId: selectedState.Id));
				break;
			}
			if (!AnsiConsole.Confirm($"Do you want to select another game?"))
			{
				break;
			}
			
		}
	}
}