using System;

public class Wheel
{
	public List<Spot> spots = new List<Spot>();
	public HashSet<Spot> bets = new HashSet<Spot>(); 

	public Wheel()
	{
		spots.Add(new Spot(0, "Green"));
		for(int i = 1; i<37; i++)
		{
			spots.Add(new Spot(i, i % 2 == 0 ? "Red" : "Black"));
		}
	}
	public Spot spin()
	{
		Random random = new Random();
		return spots[random.Next(37)];
	}
	public void addBets(string bet)
	{
		switch (bet)
		{
			case "red":
				{
					IEnumerable<Spot> query = spots.Where(spot => spot.color == "Red");
					bets.UnionWith(query);
					break;
                }
            case "black":
				{
					IEnumerable<Spot> query = spots.Where(spot => spot.color == "Black");
					bets.UnionWith(query);
					break;
				}
			default:
				{
					try
					{
						bets.Add(spots[Convert.ToInt32(bet)]);
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
}
