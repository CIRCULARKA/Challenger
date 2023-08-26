using FluentValidation;

using Challenger.Data.Models;

namespace Challenger.Data.Validation;

public class UserValidator : AbstractValidator<User>
{
	public UserValidator()
	{
		RuleFor(u => u.Login).Length(3, 255).WithMessage("Login can't be larger than 255 symbols and shorter than 3 symbols");
		RuleFor(u => u.Age).InclusiveBetween<User, short>(0, 120).WithMessage("Your age should be real");
		RuleFor(u => u.Weight).InclusiveBetween<User, short>(0, 500).WithMessage("Your weight should be real");
		RuleFor(u => u.Email).EmailAddress().WithMessage("Specify valid email address");
	}
}
