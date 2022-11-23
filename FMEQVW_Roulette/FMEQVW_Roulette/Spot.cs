using System;

public sealed record Spot
{
	public int number { get; }
	public string color { get; }

	public Spot(int number, string color)
	{
		this.number = number;
		this.color = color;
	}
	public override string ToString()
	{
        return String.Format("Szám:{0}, Szín:{1}",this.number, this.color);
    }

}
