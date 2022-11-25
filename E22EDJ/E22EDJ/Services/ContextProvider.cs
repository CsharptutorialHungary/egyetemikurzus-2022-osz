using Microsoft.EntityFrameworkCore;

namespace E22EDJ.Services;

public static class ContextProvider
{
	static ContextProvider()
	{
		Context = new GttContext();
		Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
	}
	
	public static readonly GttContext Context;
}