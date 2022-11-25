
using E22EDJ.Services;
using Spectre.Console;

namespace E22EDJ.Commands.GameRelated;

public class AddGameCommand : IConsoleCommand
{
	public string Name => "add_game";
	public string Description => "Add a brand new game you are playing";
	private readonly GameService _gameService = new();
	public void Execute()
	{
		string title;
		do
		{
			title = AnsiConsole.Ask<string>("What is the [red]title[/] of the game?");
		} while (title != "" && !AnsiConsole.Confirm($"Is the title of your new game: [red]{title}[/]?"));

		try
		{
			_gameService.Create(title);
			AnsiConsole.Write(new Markup($"[green]Game created successfully with title[/]: {title} \n"));
		}
		catch (Exception e)
		{
			AnsiConsole.Write(new Markup($"[red]Error creating the game[/] {Emoji.Known.CryingFace} \n"));
		}
	}
}