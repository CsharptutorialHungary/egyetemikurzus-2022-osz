using E22EDJ.DBModels;
using Spectre.Console;

namespace E22EDJ.Commands;

public static class GameStateConsoleCommandHelper
{
	public static GameState PromptUserToSelectGameState(List<GameState> gameStates, string promptText = "[green]Which state is your game in?[/]")
	{
		var selectedState = AnsiConsole.Prompt(
			new SelectionPrompt<string>()
				.Title(promptText)
				.PageSize(10)
				.MoreChoicesText("[grey](Move up and down to reveal more game states)[/]")
				.AddChoices(GetGameTitles(gameStates)));

		return gameStates.Find(game => game.Name == selectedState)!;
	}
	
	private static List<String> GetGameTitles(List<GameState> gameStates)
	{
		return gameStates.Select(gameState => gameState.Name).ToList();
	}
}