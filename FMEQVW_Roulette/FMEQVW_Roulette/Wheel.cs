using FMEQVW_Roulette;
using System;
using System.Runtime.ExceptionServices;

public class Wheel
{
	public List<Spot> spots = new List<Spot>();
	public HashSet<Spot> selections = new HashSet<Spot>();
	public int currentBetAmount = 0;

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
		Console.WriteLine(String.Format("result: {0}", result.ToString()) );
		int prize = currentBetAmount*(spots.Count/selections.Count);
		if(selections.Contains(result))
		{
            player.currency += prize;
        }
		currentBetAmount = 0;
	}
	public void SetBet(Player player, string betAmount)
	{
		int bet = 0;
		try { 
			bet = Convert.ToInt32(betAmount);
		}
		catch(Exception e) 
		{ 
			Console.WriteLine("Hiba történt: {0}", e.Message);
			Console.ReadKey();
		}

		if (player.currency < bet)
		{
			Console.WriteLine("Not enough money.");
			Console.ReadKey();
			return;
		}
		currentBetAmount = bet;
	}
	public void Command(string command, Player player)
	{
		string[] parts = command.Split(" ");
		if(parts.Length != 2 && parts[0]!="S")
		{
			Console.WriteLine("Invalid input.");
			return;
		}
		switch(parts[0])
		{
			case "select":
				{
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
            case "S":
                {
					player.currency -= currentBetAmount;
					Spin(player);
					Console.ReadKey();
                    break;
                }
			case "save":
				{
					WriteXml.Write(player, parts[1]);
					break;
                }
			case "load":
				{
					WriteXml.Read(player, parts[1]);
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
					IEnumerable<Spot> query = spots.Where(spot => spot.Color == "Red");
					selections.UnionWith(query);
					break;
                }
            case "black":
				{
					IEnumerable<Spot> query = spots.Where(spot => spot.Color == "Black");
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
					selections.RemoveWhere(spot => spot.Color == "Red");
                    break;
                }
            case "black":
                {
					selections.RemoveWhere(spot => spot.Color == "Black");
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
