using Microsoft.EntityFrameworkCore;

namespace E22EDJ.Models;

public class GTTContext : DbContext
{
	public DbSet<Game> Games { get; set; }
	public DbSet<GameState> GameStates { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseMySQL("server=localhost;port=3306;database=GameTimeTracker;user=root;password=admin");
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Game>()
			.HasKey(game => game.GameId);

		modelBuilder.Entity<GameState>()
			.HasKey(gameSate => gameSate.GameStateId);
	}
}