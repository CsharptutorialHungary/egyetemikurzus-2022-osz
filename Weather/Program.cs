using System.Reflection;
using Weather;

internal class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Your friendly neighborhood Weather Application!\nType in your commands!");
        var loader = new WeatherCommandLoader();
        try
        {
            while (true)
            {
                Console.Write(">: ");
                string? command = Console.ReadLine();
                if (!string.IsNullOrEmpty(command) && loader.Commands.ContainsKey(command))
                {
                    loader.Commands[command].Execute().Wait();
                }
                else
                {
                    Console.WriteLine("The action you are looking for is unavailable!");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Something went wrong during processing youre action: {e.Message}");
        }
        await Task.Delay(1000);
    }
}