using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;

namespace Challenger.Server;

public class Startup
{
	public IConfiguration Configuration { get; init; }

	public Startup(IConfiguration config)
	{
		Configuration = config;
	}

	public void ConfigureServices(IServiceCollection services)
	{
		services.AddControllers();
		Console.WriteLine("Connection string: " + Configuration["ConnectionString"]);
	}

	public void Configure(IApplicationBuilder app)
	{
	}
}
