using System.ComponentModel.DataAnnotations;

namespace E22EDJ.Models;

public class GameState
{
	public int GameStateId { get; set; }
	public string Name { get; set; }
	public bool IsDeleted { get; set; }
}