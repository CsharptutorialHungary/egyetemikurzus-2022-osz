using E22EDJ.DBModels;
using E22EDJ.Repositories;

namespace E22EDJ.Services;

public class GameStateService
{
	private readonly GameStateRepository _gameStateRepository = new();
	
	public List<GameState> GetAllGameStates()
	{
		return _gameStateRepository.GetAll();
	}
}