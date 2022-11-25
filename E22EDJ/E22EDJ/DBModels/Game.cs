using E22EDJ.TimeHandler;

namespace E22EDJ.DBModels;

public class Game : Model
{
	
	public Game(){}

	public Game(string name, int stateId = 1)
	{
		Name = name;
		GameStateId = stateId;
	}
	public Time TimeSpent { get; set; } = new();
	public DateTime StartedAt { get; set; }
	public DateTime FinishedAt { get; set; }
	
	public int GameStateId { get; set; }
	public GameState GameState { get; set; }
}