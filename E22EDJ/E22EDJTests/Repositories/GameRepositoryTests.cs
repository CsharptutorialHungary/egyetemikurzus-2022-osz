using E22EDJ.AppModels;
using E22EDJ.DBModels;
using E22EDJ.Exceptions;
using E22EDJ.Repositories;

namespace E22EDJTests.Repositories;

[TestClass]
public class GameRepositoryTests
{
	private readonly GameRepository _gameRepository = new();

	[TestMethod]
	public void WhenGameIdDoesntExistGetOneGameThrowsException()
	{
		Assert.ThrowsException<EntityNotFoundException>(() => _gameRepository.GetById(1000000000));
	}
	
	[TestMethod]
	public void GetAllShouldReturnAListofGames()
	{
		List<Game?> games = _gameRepository.GetAll();
		Assert.IsTrue(games.Count >= 0);
	}

	[TestMethod]
	public void CreatingAGameShouldInsertToDatabase()
	{
		var gameName = "My Little Pony Simulator";
		_gameRepository.CreateGame(gameName);

		var game = _gameRepository.GetByName(gameName);
		
		Assert.AreEqual(game.Name, gameName);
	}

	[TestMethod]
	public void UpdatingAGameShouldChangeTheDataInTheDatabase()
	{
		const string gameName = "My Little Pony Simulator";
		_gameRepository.CreateGame(gameName);

		var game = _gameRepository.GetByName(gameName);
		const string updatedGameName = "Super duper cool game";
		var updatedGame = _gameRepository.Update(game.Id, new UpdateGame(name: updatedGameName));
		
		Assert.AreEqual(updatedGame.Name, updatedGameName);
	}

	[TestMethod]
	public void DeletingGamesShouldBeRemovedFromTheDatabase()
	{
		_gameRepository.CreateGame("My awesome game");
		var game = _gameRepository.GetByName("My awesome game");
		_gameRepository.SoftDeleteGame(game.Id);

		Assert.ThrowsException<EntityNotFoundException>(() => _gameRepository.GetById(game.Id));
	}




}