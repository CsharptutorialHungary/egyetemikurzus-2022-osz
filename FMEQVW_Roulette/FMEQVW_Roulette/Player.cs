using System;

public class Player
{
	public string Name { get; set; }
	public int currency { get; set; }

	public Player()
	{
		Name = string.Empty;
		currency = 50000;
	}

	public Player(string name, int currency)
	{
		this.Name = name;
		this.currency=currency;
	}
}
