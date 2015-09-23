using FluentValidation;
using FluentValidation.Results;
using HR.Contracts.Domain.Abstract;
using HR.Contracts.Services.Dto;

namespace HR.Contracts.Services.Validators
{
    class ContractValidator : AbstractValidator<DtoContract>
    {
        public ContractValidator(ISalaryPolicy policy, ISalaryCalculator calculator)
        {
            this.RuleFor(x => x.Name).NotNull().NotEmpty();
            this.Custom(x => 
            {
                var minWage = policy.GetMinimumWage(x.Type, x.Experience);
                var salary = calculator.Calculate(x.Type, x.Experience, minWage);

                return x.Salary != salary ? new ValidationFailure("salary", "The value does not match calculated value.") : null;
            });
        }
    }
}