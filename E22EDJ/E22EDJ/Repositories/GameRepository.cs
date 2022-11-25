using E22EDJ.AppModels;
using E22EDJ.DBModels;
using E22EDJ.Services;
using Microsoft.EntityFrameworkCore;

namespace E22EDJ.Repositories;

public class GameRepository : Repository<Game>
{

	private readonly GttContext _database = ContextProvider.Context;

	public new List<Game?> GetAll()
	{
		try
		{
			return _database.Games.Include(game => game.GameState).Where(game => !game.IsDeleted).ToList();

		}
		catch (Exception e)
		{
			throw;
		}
	}

	public List<Game?> GetNotCompleted()
	{
		return _database.Games.Include(game => game.GameState).Where(game => !game.IsDeleted && game.GameState.Name != "Completed").ToList();
	}

	public List<Game?> GetDeletedGames()
	{
		return _database.Games.Include(game => game.GameState).Where(game => game.IsDeleted).ToList();
	}

	public void CreateGame(string name, int stateId = 1)
	{
		Game newGame = new()
		{
			Name = name,
			GameStateId = stateId
		};
		_database.Games.Add(newGame);
		_database.SaveChanges();
	}

	public void SoftDeleteGame(int gameId)
	{
		Update(gameId, new UpdateGame(isDeleted: true));
	}
}