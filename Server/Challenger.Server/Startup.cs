using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;

using FluentValidation;

using Challenger.Data;
using Challenger.Data.Models;
using Challenger.Application.Validation;

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
		services.AddTransient<DbContext>((provider) =>
			new DbContext(Configuration.GetConnectionString("Local"))
		);
		services.AddTransient<IValidator<User>, UserValidator>();

		services.AddControllers();
	}

	public void Configure(IApplicationBuilder app)
	{
		app.UseRouting();
		app.UseEndpoints(endpoint => endpoint.MapControllers());
	}
}
