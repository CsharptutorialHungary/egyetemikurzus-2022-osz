using System;

public class Player
{
	public string name { get; set; }
	public int currency { get; set; }

	public Player()
	{
		name = string.Empty;
		currency = 0;
	}

	public Player(string name, int currency)
	{
		this.name = name;
		this.currency=currency;
	}
}
