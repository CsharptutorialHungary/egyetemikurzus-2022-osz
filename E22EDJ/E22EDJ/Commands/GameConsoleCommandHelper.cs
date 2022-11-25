using E22EDJ.DBModels;
using Spectre.Console;

namespace E22EDJ.Commands;

public static class GameConsoleCommandHelper
{
	public static Game PromptUserToSelectGame(List<Game> games, string promptText = "[green]Which game are you playing?[/]")
	{
		var selectedTitle = AnsiConsole.Prompt(
			new SelectionPrompt<string>()
				.Title(promptText)
				.PageSize(10)
				.MoreChoicesText("[grey](Move up and down to reveal more games)[/]")
				.AddChoices(GetGameTitles(games)));

		return games.Find(game => game.Name == selectedTitle)!;
	}
	
	private static List<String> GetGameTitles(List<Game> games)
	{
		return games.Select(game => game.Name).ToList();
	}
}