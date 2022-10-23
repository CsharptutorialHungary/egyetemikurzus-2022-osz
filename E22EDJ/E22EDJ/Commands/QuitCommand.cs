using System.Diagnostics;

namespace E22EDJ.Commands;

public class QuitCommand : IConsoleCommand
{
	public string Name => "quit";
	public string Description => "Closes the application";
	public void Execute()
	{
		System.Environment.Exit(0);
	}
}