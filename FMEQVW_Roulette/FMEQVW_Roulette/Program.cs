Console.WriteLine("Add meg a játékos nevét:");
Player player = new Player();
//player.name = Console.ReadLine();
string input = string.Empty;
Wheel wheel = new Wheel();
while (input!="Q"){
    Console.Write("Kilépés: Q\nPörgetés: P\n");
    switch (input)
    {
        case "P":
            Console.WriteLine(wheel.spin().ToString());
            break;
        default:
            break;
    }
    //TODO: game loop
    input = Console.ReadLine();
}

Console.ReadKey();