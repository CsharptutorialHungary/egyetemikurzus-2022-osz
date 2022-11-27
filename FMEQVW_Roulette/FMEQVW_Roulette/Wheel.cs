using System;
using System.Runtime.ExceptionServices;

public class Wheel
{
	public List<Spot> spots = new List<Spot>();
	public HashSet<Spot> selections = new HashSet<Spot>();
	int currentBetAmount = 0;

	public Wheel()
	{
		spots.Add(new Spot(0, "Green"));
		for(int i = 1; i<37; i++)
		{
			spots.Add(new Spot(i, i % 2 == 0 ? "Red" : "Black"));
		}
	}
	public void Spin(Player player)
	{

		Random random = new Random();
		Spot result = spots[random.Next(37)];
		Console.WriteLine(result.ToString() );
		int prize = currentBetAmount*(spots.Count/selections.Count);
		Console.WriteLine(selections.Count.ToString() );
		Console.WriteLine( spots.Count.ToString() );
		if(selections.Contains(result))
		{
            player.currency += prize;
        }
		currentBetAmount = 0;
	}
	public void SetBet(Player player, string betAmount)
	{
		int bet = Convert.ToInt32(betAmount);
		if (player.currency < bet)
		{
			Console.WriteLine("Not enough money.");
			return;
		}
		currentBetAmount = bet;
	}
	public void Command(string command, Player player)
	{
		string[] parts = command.Split(" ");
		if(parts.Length != 2 && parts[0]!="P")
		{
			Console.WriteLine("Invalid input.");
			return;
		}
		switch(parts[0])
		{
			case "select":
				{
					player.currency += 10000;
					AddSelections(parts[1]);
					break;
				}
			case "remove":
				{
					RemoveSelections(parts[1]);
					break;
				}
			case "bet":
                {
					SetBet(player, parts[1]);
                    break;
                }
            case "P":
                {
					player.currency -= currentBetAmount;
					Spin(player);
					Console.ReadKey();
                    break;
                }
            default:
				{
					Console.WriteLine("Invalid input.");
					Console.ReadKey();
					break;
				}
		}

	}
	public void AddSelections(string selection)
	{
		switch (selection)
		{
			case "red":
				{
					IEnumerable<Spot> query = spots.Where(spot => spot.color == "Red");
					selections.UnionWith(query);
					break;
                }
            case "black":
				{
					IEnumerable<Spot> query = spots.Where(spot => spot.color == "Black");
					selections.UnionWith(query);
					break;
				}
			default:
				{
					try
					{
						selections.Add(spots[Convert.ToInt32(selection)]);
					}
					catch(Exception e) 
					{
						Console.WriteLine("Hiba: {0}", e.Message);
                        Console.ReadKey();
                    }
					break;
				}
				
		}
	}
    public void RemoveSelections(string selection)
    {
        switch (selection)
        {
            case "red":
                {
					selections.RemoveWhere(spot => spot.color == "Red");
                    break;
                }
            case "black":
                {
					selections.RemoveWhere(spot => spot.color == "Black");
                    break;
                }
            default:
                {
                    try
                    {
                        selections.Remove(spots[Convert.ToInt32(selection)]);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Hiba: {0}", e.Message);
                        Console.ReadKey();
                    }
                    break;
                }

        }
    }
}
