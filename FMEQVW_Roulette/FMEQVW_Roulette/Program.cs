using FMEQVW_Roulette;
using System.Runtime.CompilerServices;

Console.WriteLine("Enter player name:");
Player player = new Player();
player.Name = Console.ReadLine();
string? input = string.Empty;
Wheel wheel = new Wheel();
while (input!="Q"){
    
    Console.Write(String.Format("Name: {0}\t\tCurrency: {1}\t\tCurrent bet: {2}\nQuit: Q\t\tSpin: S\t\tSelect all red tiles: red\t\tSelect all black tiles: black\n\n",player.Name,player.currency,wheel.currentBetAmount));
    Console.WriteLine("Current bets:");
    wheel.selections.OrderBy(bet => bet.Number).ToList().ForEach(bet => Console.WriteLine(bet.ToString()));
    Console.Write("\nEnter command: \n");
    StringWriter iro = new StringWriter();
    iro.WriteLineAsync("XDDDDDD");
    input = Console.ReadLine();
    if (null == input) { continue; };
    wheel.Command(input, player);
    Console.Clear();
}
await Wheel.GameOver();
Console.ReadKey();