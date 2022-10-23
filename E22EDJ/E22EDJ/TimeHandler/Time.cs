using System.ComponentModel.DataAnnotations;

namespace E22EDJ.TimeHandler;

public class Time
{

	public Time()
	{
		Hours = 0;
		Minutes = 0;
		Seconds = 0;
	}
	
	public Time(int hours, int minutes, int seconds)
	{
		Hours = hours;
		Minutes = minutes;
		Seconds = seconds;
	}

	public Time(string time)
	{
		string[] segments = time.Split(":");
		Hours = int.Parse(segments[0]);
		Minutes = int.Parse(segments[1]);
		Seconds = int.Parse(segments[2]);
	}
	
	public int Hours { get; set; }
	private int _minutes;
	private int _seconds;

	public static Time operator +(Time currentTime, string timeToAdd)
	{
		var segmentToIncrement = timeToAdd.Substring(timeToAdd.Length - 1);
		var amountOfTimeIncrementWith = int.Parse(timeToAdd.Remove(timeToAdd.Length - 1));

		switch (segmentToIncrement)
		{
			case "h":
				currentTime.Hours += amountOfTimeIncrementWith;
				break;
			case "m":
				currentTime.Minutes += amountOfTimeIncrementWith;
				break;
			case "s":
				currentTime.Seconds += amountOfTimeIncrementWith;
				break;
		}

		return currentTime;
	}
	
	[Required]
	public int Minutes
	{
		get => _minutes;
		set
		{
			while (value >= 60)
			{
				Hours++;
				value -= 60;
				_minutes = 0;
			}

			_minutes = value;
		}
	}

	[Required]
	public int Seconds
	{
		get => _seconds;
		set
		{
			while (value >= 60)
			{
				Minutes++;
				value -= 60;
				_seconds = 0;
			}

			_seconds = value;
		}
	}

	public override string ToString()
	{
		return $"{Hours}:{Minutes}:{Seconds}";
	}
}