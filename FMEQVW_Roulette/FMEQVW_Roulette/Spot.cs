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
        return String.Format("Number:{0}, Color:{1}",this.number, this.color);
    }

}
