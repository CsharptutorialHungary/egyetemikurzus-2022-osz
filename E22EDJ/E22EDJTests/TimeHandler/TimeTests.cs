using E22EDJ.TimeHandler;

namespace E22EDJTests.TimeHandler;

[TestClass]
public class TimeTests
{
	[TestMethod]
	public void CreatingTimeFromString()
	{
		var timeString = "1:02:03";

		var time = new Time(timeString);
		
		Assert.AreEqual(time.Hours, 1);
		Assert.AreEqual(time.Minutes, 2);
		Assert.AreEqual(time.Seconds, 3);
	}
	
	
	[TestMethod]
	public void AddingHours()
	{
		var time = new Time();
		time += "2h";
		Assert.AreEqual(time.Hours, 2);
	}

	[TestMethod]
	public void AddingZeroHours()
	{
		var time = new Time();
		time += "0h";
		Assert.AreEqual(time.Hours, 0);
	}

	[TestMethod]
	public void AddingMinutes()
	{
		var time = new Time();
		time += "2m";
		Assert.AreEqual(time.Minutes, 2);
	}

	[TestMethod]
	public void AddingMinutesOverSixtyShouldIncrementHours()
	{
		var time = new Time();
		time += "121m";
		
		Assert.AreEqual(time.Hours, 2);
		Assert.AreEqual(time.Minutes, 1);
	}
	
	[TestMethod]
	public void AddingMinutesShouldIncrementHoursIfMinutesIsOverSixty()
	{
		var time = new Time(0, 10,0);
		time += "51m";
		Assert.AreEqual(time.Hours, 1);
		Assert.AreEqual(time.Minutes, 1);
	}
	
	[TestMethod]
	public void AddingZeroMinutes()
	{
		var time = new Time(0, 10,0);
		time += "0m";
		Assert.AreEqual(time.Minutes, 10);
	}
	
	public void AddingSeconds()
	{
		var time = new Time();
		time += "2s";
		Assert.AreEqual(time.Seconds, 2);
	}

	[TestMethod]
	public void AddingSecondsOverSixtyShouldIncrementMinutes()
	{
		var time = new Time();
		time += "121s";
		
		Assert.AreEqual(time.Minutes, 2);
		Assert.AreEqual(time.Seconds, 1);
	}
	
	[TestMethod]
	public void AddingSecondsShouldIncrementMinutesIfSecondsIsOverSixty()
	{
		var time = new Time(0, 0,10);
		time += "51s";
		Assert.AreEqual(time.Minutes, 1);
		Assert.AreEqual(time.Seconds, 1);
	}
	
	[TestMethod]
	public void AddingZeroSeconds()
	{
		var time = new Time(0, 0,10);
		time += "0s";
		Assert.AreEqual(time.Seconds, 10);
	}

	[TestMethod]
	public void AddingSecondsShouldIncreaseMinutesAndHoursAccordingly()
	{
		var time = new Time();
		time += "3723s";
		Assert.AreEqual(time.Hours, 1);
		Assert.AreEqual(time.Minutes, 2);
		Assert.AreEqual(time.Seconds, 3);
	}

	[TestMethod]
	public void ToStringDisplaysTheRightTimeIfSegmentValueIsUnder10()
	{
		var time = new Time(1,1,1);
		Assert.AreEqual(time.ToString(), "1:01:01");
	}

	[TestMethod]
	public void ToStringDisplaysTheRightTimeIfSegmentValueIsOver10()
	{
		var time = new Time(1,34,41);
		Assert.AreEqual(time.ToString(), "1:34:41");
	} 
	
	
}