Console.WriteLine("Enter player name:");
Player player = new Player();
player.name = Console.ReadLine();
string? input = string.Empty;
Wheel wheel = new Wheel();
while (input!="Q"){
    
    Console.Write(String.Format("Name: {0}\t\tCurrency: {1}\nQuit: Q\t\tSpin: S\t\tSelect all red tiles: red\t\tSelect all black tiles: black\n\n",player.name,player.currency));
    Console.WriteLine("Current bets:");
    wheel.selections.OrderBy(bet => bet.number).ToList().ForEach(bet => Console.WriteLine(bet.ToString()));
    Console.WriteLine("\n");
    input = Console.ReadLine();
    if (null == input) { continue; };
    wheel.Command(input, player);
    Console.Clear();
}

Console.ReadKey();