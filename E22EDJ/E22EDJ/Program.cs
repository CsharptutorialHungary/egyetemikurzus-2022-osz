using E22EDJ.DBModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Spectre.Console;

namespace E22EDJ;

public static class Program
{
	static void Main(string[] args)
	{
		using IHost host = Host.CreateDefaultBuilder(args)
			.ConfigureServices((_, services) =>
			{
				services.AddSingleton<GttContext>();
			}).Build();
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