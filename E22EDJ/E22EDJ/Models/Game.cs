using System.ComponentModel.DataAnnotations;
using E22EDJ.TimeHandler;

namespace E22EDJ.Models;

public class Game
{
	public int GameId { get; set; }
	public string Name { get; set; }
	public string TimeSpent { get; set; }
	public int StateId { get; set; }
	public DateTime StartedAt { get; set; }
	public DateTime FinishedAt { get; set; }
	public bool IsDeleted { get; set; }
}