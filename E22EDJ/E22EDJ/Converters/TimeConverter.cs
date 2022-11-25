using E22EDJ.TimeHandler;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace E22EDJ.Converters;

public class TimeConverter : ValueConverter<Time, string>
{
	public TimeConverter()
		:base(
			time => time.ToString(), 
			time => new Time(time)
		)
	{}
}