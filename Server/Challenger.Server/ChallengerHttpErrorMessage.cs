using System.Linq;
using System.Collections.ObjectModel;

using FluentValidation.Results;

using System;

public class ChallengerHttpErrorMessage
{
	public ChallengerHttpErrorMessage(ValidationResult result)
	{
		if (result is null) throw new ArgumentNullException("Validation result can not be null");
		if (result.Errors.Count == 0) throw new InvalidOperationException("There are no errors in validation result to construct the error message");

		Errors = new ReadOnlyCollection<string>(
			result.Errors.Select(e => e.ErrorMessage).ToList()
		);
	}

	public ReadOnlyCollection<string> Errors { get; init; }
}
