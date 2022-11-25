using E22EDJ.AppModels;
using E22EDJ.DBModels;
using E22EDJ.Services;
using E22EDJ.TimeHandler;
using Spectre.Console;

namespace E22EDJ.Commands.GameRelated;

public class LogTimeToGameCommand : IConsoleCommand
{
	public string Name => "log_time";
	public string Description => "Log time to existing game";
	private readonly GameService _gameService = new();
	public void Execute()
	{
		const char quitButton = 'q';
		
		var games = _gameService.GetNotCompletedGames();
		var selectedGame = GameConsoleCommandHelper.PromptUserToSelectGame(games, "[green]Which game are you playing?[/] [gray](completed games are not listed)[/]");
		
		AnsiConsole.Write(new Markup($"Press [green]'{quitButton}'[/] to stop the timer \n"));

		var isQuitButtonPressed = false;
		Task.Run(() =>
		{
			var currentSessionTimer = new Time();
			//isQuitButtonPressed is modified outside the task. Idk how good is that.
			// ReSharper disable once LoopVariableIsNeverChangedInsideLoop
			// ReSharper disable once AccessToModifiedClosure
			while (!isQuitButtonPressed)
			{
				//Couldn't figure out how to write this in multiple lines.
				AnsiConsole.Write($"\rTime spent in [red]current session[/]: {currentSessionTimer} Time spent in [red]total[/]: {selectedGame.TimeSpent}");
				Thread.Sleep(1000);
				currentSessionTimer++;
				selectedGame.TimeSpent++;
			}
		});

		ConsoleKeyInfo input;
		do
		{
			input = Console.ReadKey();
		} while (input.KeyChar != quitButton);
		
		isQuitButtonPressed = true;
		Console.WriteLine();
		UpdateGame(selectedGame);
	}

	private void UpdateGame(Game game)
	{
		_gameService.Update(game.Id, new UpdateGame(timeSpent: game.TimeSpent));
	}
}