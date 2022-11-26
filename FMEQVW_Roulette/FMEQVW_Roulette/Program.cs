Console.WriteLine("Enter player name:");
Player player = new Player();
player.name = Console.ReadLine();
string? input = string.Empty;
Wheel wheel = new Wheel();
while (input!="Q"){
    
    Console.Write(String.Format("Name: {0}\t\tCurrency: {1}\nQuit: Q\t\tSpin: S\t\tSelect all red tiles: red\t\tSelect all black tiles: black\n\n",player.name,player.currency));
    Console.WriteLine("Current bets:");
    wheel.bets.OrderBy(bet => bet.number).ToList().ForEach(bet => Console.WriteLine(bet.ToString()));
    input = Console.ReadLine();
    if (null == input) { continue; };
    switch (input)
    {
        case "P":
            {
                Console.WriteLine(wheel.spin().ToString());
                break;
            }
        default:
            {
                wheel.addBets(input);
                break;
            }
    }
    Console.Clear();
    //TODO: game loop
}

Console.ReadKey();