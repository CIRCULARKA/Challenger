namespace Challenger.Server;

public class Startup
{
	public void ConfigureServices(IServiceCollection services)
	{
		services.AddControllers();
	}

	public void Configure(IApplicationBuilder app)
	{
	}
}
