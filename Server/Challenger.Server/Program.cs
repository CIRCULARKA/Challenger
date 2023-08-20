using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Challenger.Server;

public class Program
{
	public static void Main(string[] args)
	{
		var app = CreateHostBuilder(args);
		app.Build().Run();
	}

	public static IHostBuilder CreateHostBuilder(string[] args) =>
		Host.CreateDefaultBuilder(args).
			ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
}
