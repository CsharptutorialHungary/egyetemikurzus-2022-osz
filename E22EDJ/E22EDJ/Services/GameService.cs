using E22EDJ.AppModels;
using E22EDJ.DBModels;
using E22EDJ.Repositories;

namespace E22EDJ.Services;

public class GameService
{

	private readonly GameRepository _gameRepository = new();

	public List<Game> GetAllGames()
	{
		return _gameRepository.GetAll();
	}
	
	public List<Game> GetNotCompletedGames()
	{
		return _gameRepository.GetNotCompleted();
	}
	
	public Game GetGameById(int id)
	{
		return _gameRepository.GetById(id);
	}

	public Game GetByName(string name)
	{
		return _gameRepository.GetByName(name);
	}

	public void Create(string name, int stateId = 1)
	{
		_gameRepository.CreateGame(name, stateId);
	}

	public Game Update(int id, UpdateGame updateGame)
	{
		return _gameRepository.Update(id, updateGame);
	}

	public void Delete(int id)
	{
		_gameRepository.SoftDeleteGame(id);
	}
	
}