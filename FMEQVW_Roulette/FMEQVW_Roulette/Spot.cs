using System;

public sealed record Spot
{
	public int Number { get; }
	public string Color { get; }

	public Spot(int number, string color)
	{
		this.Number = number;
		this.Color = color;
	}
	public override string ToString()
	{
        return String.Format("Number:{0}, Color:{1}",this.Number, this.Color);
    }

}
