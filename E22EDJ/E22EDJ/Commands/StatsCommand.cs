using E22EDJ.AppModels;
using E22EDJ.Builders;
using E22EDJ.DBModels;
using E22EDJ.Services;
using E22EDJ.TimeHandler;
using Spectre.Console;

namespace E22EDJ.Commands;

public class StatsCommand : IConsoleCommand
{
	public string Name => "stats";
	public string Description => "get your overall stats";
	private readonly GameService _gameService = new();
	private List<Game?> _games;

	public void Execute()
	{
		try
		{
			this._games = _gameService.GetAllGames();
		}
		catch (Exception e)
		{
			AnsiConsole.Write(new Markup("[red]Error getting the games from the database![/] \n"));
			return;
		}
		var statBuilder = new StatsBuilder();
		var stats = statBuilder
			.SetNumberOfGames(GetNumberOfGames())
			.SetGamesCompleted(GetGamesCompleted())
			.SetGamesOnGoing(GetGamesOnGoing())
			.SetGamesPlaned(GetGamesPlanned())
			.SetGamesDeleted(GetGamesDeleted())
			.SetTotalTimeSpent(GetTotalTimeSpent())
			.SetGameWithMostLoggedTime(GetGameWithMostLoggedTime())
			.SetAverageTimeSpentWithGames(GetAverageTimeSpentOnGames())
			.Build();
		

		var table = new Table();

		table.AddColumn("[green]Stat[/]");
		table.AddColumn("[green]Value[/]");

		table.AddRow("Total time spent", stats.TotalTimeSpent.ToString());

		string mostPlayedGameTitle = stats.GameWithMostLoggedTime != null
			? stats.GameWithMostLoggedTime.Name
			: "----";
		
		table.AddRow("Most played game", mostPlayedGameTitle);
		table.AddRow("Average time spent", stats.AverageTimeSpentWithGames.ToString());
		
		AnsiConsole.Write(
			new BarChart()
				.Width(60)
				.Label("Game Stats")
				.CenterLabel()
				.AddItem("Number of Games", stats.NumberOfGames, Color.White)
				.AddItem("Completed Games", stats.GamesCompleted, Color.Green)
				.AddItem("On Going Games", stats.OnGoingGames, Color.Orange1)
				.AddItem("Planned Games", stats.GamesPlaned, Color.Blue)
				.AddItem("Deleted Games", stats.GamesDeleted, Color.Red)
		);
		
		AnsiConsole.Write(table);
	}


	private int GetNumberOfGames()
	{
		return this._games.Count();
	}

	private int GetGamesCompleted()
	{
		if (!this._games.Any())
		{
			return 0;
		}
		return this._games.Count(game => game!.GameState.Name == "Completed");
	}
	
	private int GetGamesOnGoing()
	{
		if (!this._games.Any())
		{
			return 0;
		}
		return this._games.Count(game => game!.GameState.Name == "On Going");
	}
	
	private int GetGamesPlanned()
	{
		if (!this._games.Any())
		{
			return 0;
		}
		return this._games.Count(game => game!.GameState.Name == "Planned");
	}

	private int GetGamesDeleted()
	{
		return _gameService.GetDeletedGames().Count();
	}
	
	private Time GetTotalTimeSpent()
	{
		var totalTimeSpent = new Time();

		if (!this._games.Any())
		{
			return totalTimeSpent;
		}
		
		this._games.ForEach(game =>
		{
			totalTimeSpent += game!.TimeSpent;
		});

		return totalTimeSpent;
	}

	private Game? GetGameWithMostLoggedTime()
	{
		return this._games.MaxBy(game => game?.TimeSpent.InSeconds());
	}

	private Time GetAverageTimeSpentOnGames()
	{
		var time = new Time(0, 0, 0);

		if (!this._games.Any())
		{
			return time;
		}

		var timeSpentOnEachGame = new List<int>();

		this._games.ForEach(game =>
		{
			timeSpentOnEachGame.Add(game!.TimeSpent.InSeconds());
		});

		var averageTime = timeSpentOnEachGame.Average();

		return time + averageTime;

	}
}