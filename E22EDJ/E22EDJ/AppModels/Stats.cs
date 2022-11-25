using E22EDJ.DBModels;
using E22EDJ.TimeHandler;

namespace E22EDJ.AppModels;

public class Stats
{
	public int NumberOfGames { get; set; }
	public int GamesCompleted { get; set; }
	public int OnGoingGames { get; set; }
	public int GamesPlaned { get; set; }
	public int GamesDeleted { get; set; }
	public Time TotalTimeSpent { get; set; } = new();

	public Time AverageTimeSpentWithGames { get; set; } = new();
	public Game? GameWithMostLoggedTime { get; set; }
	
}