using Microsoft.Extensions.DependencyInjection;

using FluentValidation;

using Challenger.Application;
using Challenger.Application.Validation;
using Challenger.Data.Models;

namespace Challenger.Server;

public static class ChallengerServicesExtension
{
	public static IServiceCollection AddChallengerServices(this IServiceCollection services)
	{
		services.AddTransient<UserRegistry>();

		return services;
	}

	public static IServiceCollection AddChallengerValidation(this IServiceCollection services)
	{
		services.AddTransient<IValidator<User>>();

		return services;
	}
}
