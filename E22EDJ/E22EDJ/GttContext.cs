using E22EDJ.Converters;
using E22EDJ.DBModels;
using Microsoft.EntityFrameworkCore;

namespace E22EDJ;

public class GttContext : DbContext
{
	public DbSet<Game?> Games { get; set; }
	public DbSet<GameState> GameStates { get; set; }
	

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseMySQL("server=localhost;port=3306;database=GameTimeTracker;user=root;password=admin");
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Game>().HasKey(game => game.Id);

		modelBuilder
			.Entity<Game>()
			.Property(game => game.TimeSpent)
			.HasConversion<TimeConverter>();
		
		modelBuilder.Entity<Game>().Property(game => game.Id).ValueGeneratedOnAdd();

		modelBuilder.Entity<GameState>()
			.HasKey(gameSate => gameSate.Id);


		modelBuilder.Entity<GameState>()
			.HasData(
				new GameState(1, "Planned"),
				new GameState(2, "On Going"),
				new GameState(3,"Completed")
			);
	}
}