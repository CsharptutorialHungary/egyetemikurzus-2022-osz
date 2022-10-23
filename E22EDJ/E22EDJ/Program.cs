// See https://aka.ms/new-console-template for more information

using E22EDJ;

Console.WriteLine("Starting Game Time Tracker app");


var loader = new CommandLoader();

while (true)
{
    Console.WriteLine("Type in a  command: ");
    string? command = Console.ReadLine();
    if (!string.IsNullOrEmpty(command) && loader.Commands.ContainsKey(command))
    {
        loader.Commands[command].Execute();
    }
    else
    {
        Console.WriteLine($"There is no such command as: '{command}'");
    }
}