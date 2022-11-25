using Spectre.Console;

namespace E22EDJ.Commands;

public class QuitCommand : IConsoleCommand
{
	public string Name => "quit";
	public string Description => "Closes the application";
	public void Execute()
	{
		AnsiConsole.Write($"App closed. Bye! {Emoji.Known.WavingHand}");
		Thread.Sleep(2000);
		Environment.Exit(0);
	}
}