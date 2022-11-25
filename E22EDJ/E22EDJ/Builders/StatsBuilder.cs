using E22EDJ.AppModels;
using E22EDJ.DBModels;
using E22EDJ.TimeHandler;

namespace E22EDJ.Builders;

public class StatsBuilder
{
	private Stats _stats = new();

	public StatsBuilder()
	{
		this.Reset();
	}

	public Stats Build()
	{
		var createdStat =  this._stats;
		this.Reset();
		return createdStat;
	}

	public StatsBuilder SetNumberOfGames(int numberOfGames)
	{
		this._stats.NumberOfGames = numberOfGames;
		return this;
	}
	
	public StatsBuilder SetGamesCompleted(int gamesCompleted)
	{
		this._stats.GamesCompleted = gamesCompleted;
		return this;
	}
	
	public StatsBuilder SetGamesOnGoing(int gamesInProgress)
	{
		this._stats.OnGoingGames = gamesInProgress;
		return this;
	}
	
	public StatsBuilder SetGamesPlaned(int gamesPlaned)
	{
		this._stats.GamesPlaned = gamesPlaned;
		return this;
	}

	public StatsBuilder SetGamesDeleted(int gamesDeleted)
	{
		this._stats.GamesDeleted = gamesDeleted;
		return this;
	}
	
	public StatsBuilder SetTotalTimeSpent(Time totalTimeSpent)
	{
		this._stats.TotalTimeSpent = totalTimeSpent;
		return this;
	}

	public StatsBuilder SetAverageTimeSpentWithGames(Time averageTimeSpentWithGames)
	{
		this._stats.AverageTimeSpentWithGames = averageTimeSpentWithGames;
		return this;
	}
	
	
	public StatsBuilder SetGameWithMostLoggedTime(Game? gameWithMostLoggedTime)
	{
		this._stats.GameWithMostLoggedTime = gameWithMostLoggedTime;
		return this;
	}
	
	private void Reset()
	{
		this._stats = new Stats();
	}
	
}