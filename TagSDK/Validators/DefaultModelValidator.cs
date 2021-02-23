using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TagSDK.Validators
{
    public class DefaultModelValidator : IModelValidator
    {
        private readonly Dictionary<Type, IEnumerable<FluentValidation.IValidator>> _validatorsInstance = new Dictionary<Type, IEnumerable<FluentValidation.IValidator>>();
        private readonly Dictionary<Type, IEnumerable<Type>> _validators = new Dictionary<Type, IEnumerable<Type>>();

        public DefaultModelValidator(Dictionary<Type, IEnumerable<Type>> validators)
        {
            _validators = validators;
        }

        private IEnumerable<FluentValidation.IValidator> InstantiateValidators<T>()
        {
            var type = typeof(FluentValidation.IValidator<T>);
            return _validators.ContainsKey(type) ? _validators[type]
                .Select(a => Activator.CreateInstance(a)).Cast<FluentValidation.IValidator>() : new List<FluentValidation.IValidator>();
        }

        private IEnumerable<FluentValidation.IValidator> GetValidators<T>()
        {
            if (!_validatorsInstance.ContainsKey(typeof(T)))
            {
                _validatorsInstance.Add(typeof(T), InstantiateValidators<T>());
            }

            return _validatorsInstance[typeof(T)];
        }

        public List<ValidationFailure> Validate<T>(T model) =>
            GetValidators<T>()
                .Select(v => v.Validate(new FluentValidation.ValidationContext<T>(model)))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();
    }
}
