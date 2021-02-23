using System;
using System.Threading.Tasks;
using TagSDK.Commands;
using TagSDK.Validators;
using System.Linq;

namespace TagSDK.Pipeline
{
    public class ValidateMidleware<T, T2> : Filter<RequestCommand<T, T2>, ResponseCommand<T2>>
    {
        protected SDKOptions Options;
        protected IModelValidator Validator;

        public ValidateMidleware(IModelValidator validator)
        {
            Validator = validator;
        }

        protected override async Task<ResponseCommand<T2>> Execute(RequestCommand<T, T2> context, Func<RequestCommand<T, T2>, Task<ResponseCommand<T2>>> next)
        {
            var failures = Validator.Validate<T>(context.Model);

            return failures.Any()
                ? throw new Exception(string.Join(",", failures))
                : await next(context);

        }
    }
}
