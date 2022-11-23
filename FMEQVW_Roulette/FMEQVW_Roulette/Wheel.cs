using System;

public class Wheel
{
	public List<Spot> spots = new List<Spot>();

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
}
