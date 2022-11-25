using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using MySql.EntityFrameworkCore.Extensions;

namespace E22EDJ.MySQLServiceRegistration;

public class MysqlEntityFrameworkDesignTimeServices : IDesignTimeServices
{
	public void ConfigureDesignTimeServices(IServiceCollection serviceCollection)
	{
		serviceCollection.AddEntityFrameworkMySQL();
		new EntityFrameworkRelationalDesignServicesBuilder(serviceCollection)
			.TryAddCoreServices();
	}
}