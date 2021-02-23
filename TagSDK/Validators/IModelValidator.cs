using System.Collections.Generic;
using FluentValidation.Results;

namespace TagSDK.Validators
{
    public interface IModelValidator
    {
        List<ValidationFailure> Validate<T>(T model);
    }
}
