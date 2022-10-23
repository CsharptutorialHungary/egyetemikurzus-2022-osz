using E22EDJ;

Console.WriteLine("Starting Game Time Tracker app");
Console.WriteLine("To get the available commands type 'help'");

var loader = new CommandLoader();

while (true)
{
	Console.Write("Type in a  command: ");
	var command = Console.ReadLine();
	if (!string.IsNullOrEmpty(command) && loader.Commands.ContainsKey(command))
	{
		loader.Commands[command].Execute();
	}
	else
	{
		Console.WriteLine($"There is no such command as: '{command}'");
	}
}