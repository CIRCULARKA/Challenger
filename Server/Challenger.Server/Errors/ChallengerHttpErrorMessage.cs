using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using FluentValidation.Results;

namespace Challenger.Server.Errors;

public class ChallengerHttpErrorMessage
{
	public ChallengerHttpErrorMessage(ValidationResult result)
	{
		if (result is null) throw new ArgumentNullException("Validation result can not be null");
		if (result.Errors.Count == 0) throw new InvalidOperationException("There are no errors in validation result to construct the error message");

		ErrorType = ChallengerErrorTypes.ValidationError.ToString();

		Errors = new ReadOnlyCollection<string>(
			result.Errors.Select(e => e.ErrorMessage).ToList()
		);
	}

	public ChallengerHttpErrorMessage(ChallengerErrorTypes errType, string error)
	{
		if (error is null) throw new ArgumentNullException("Can't build error message - no error specified");

		ErrorType = errType.ToString();

		Errors = new ReadOnlyCollection<string>(
			new List<string> { error }
		);
	}

	public string ErrorType { get; init; }

	public ReadOnlyCollection<string> Errors { get; init; }
}
