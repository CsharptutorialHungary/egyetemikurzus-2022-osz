namespace E22EDJ;

//TODO: run  dotnet ef migrations add "Create Games and GamesStates tables"

public static class Program
{
	static void Main(string[] args)
	{
		CreateAppLoop();
	}

	private static void CreateAppLoop()
	{
		Console.WriteLine("Starting Game Time Tracker app");
		Console.WriteLine("To get the available commands type 'help'");

		var loader = new CommandLoader();

		while (true)
		{
			Console.Write("Type in a  command: ");
			var command = Console.ReadLine();
			if (!string.IsNullOrEmpty(command) && loader.Commands.ContainsKey(command))
				loader.Commands[command].Execute();
			else
				Console.WriteLine($"There is no such command as: '{command}'");
		}
	}
}