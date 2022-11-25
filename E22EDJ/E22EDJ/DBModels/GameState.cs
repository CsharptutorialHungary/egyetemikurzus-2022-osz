using System.ComponentModel.DataAnnotations;

namespace E22EDJ.DBModels;

public sealed class GameState: Model
{

	public GameState(int id, string name)
	{
		Id = id;
		Name = name;
	}
	
	public List<Game> Games { get; set; }
}