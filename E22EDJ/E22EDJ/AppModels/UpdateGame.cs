using E22EDJ.DBModels;
using E22EDJ.TimeHandler;

namespace E22EDJ.AppModels;

public class UpdateGame: IModelUpdate
{
	public UpdateGame(
		string? name = null, 
		Time? timeSpent = null, 
		int? gameStateId = null, 
		DateTime? finishedAt = null, 
		bool? isDeleted = null)
	{
		Name = name;
		TimeSpent = timeSpent;
		GameStateId = gameStateId;
		FinishedAt = finishedAt;
		IsDeleted = isDeleted;
	}

	public string? Name { get; set; }
	public Time? TimeSpent { get; set; }
	public int? GameStateId { get; set; }
	public DateTime? FinishedAt { get; set; }
	public bool? IsDeleted { get; set; }
}