using System.Reflection;

namespace E22EDJ;

public class CommandLoader
{
	public CommandLoader()
	{
		Commands = new Dictionary<string, IConsoleCommand>();

		var assembly = Assembly.GetAssembly(typeof(CommandLoader));

		if (assembly == null)
			throw new InvalidOperationException("Could not get assembly with type CommandLoader");

		var types = assembly
			.GetTypes()
			.Where(type =>
				type.IsClass &&
				!type.IsAbstract &&
				type.IsAssignableTo(typeof(IConsoleCommand))
			);

		try
		{
			foreach (var type in types)
				if (Activator.CreateInstance(type) is IConsoleCommand command)
					Commands.Add(command.Name, command);
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
		}
	}

	public Dictionary<string, IConsoleCommand> Commands { get; }
}