Console.WriteLine("Add meg a játékos nevét:");
Player player = new Player();
player.name = Console.ReadLine();
Console.WriteLine(player.name);
string input = string.Empty;
while (input!="Q"){
    Console.WriteLine("Exit command: Q");
    //TODO: game loop
    input = Console.ReadLine();
}

Console.ReadKey();