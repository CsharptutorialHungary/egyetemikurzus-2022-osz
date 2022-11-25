using E22EDJ.AppModels;
using E22EDJ.DBModels;
using E22EDJ.Services;
using Microsoft.EntityFrameworkCore;

namespace E22EDJ.Repositories;

public class GameRepository : Repository<Game>
{

	private readonly GttContext _database = ContextProvider.Context;

	public new List<Game> GetAll()
	{
		return _database.Games.Include(game => game.GameState).Where(game => !game.IsDeleted).ToList();
	}

	public List<Game> GetNotCompleted()
	{
		return _database.Games.Include(game => game.GameState).Where(game => !game.IsDeleted && game.GameState.Name != "Completed").ToList();
	}

	public async void CreateGame(string name, int stateId = 1)
	{
		await _database.Games.AddAsync(new Game(name, stateId));
		await _database.SaveChangesAsync();
	}

	public void SoftDeleteGame(int gameId)
	{
		Update(gameId, new UpdateGame(isDeleted: true));
	}
}