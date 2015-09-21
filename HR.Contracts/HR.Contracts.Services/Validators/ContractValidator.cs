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
            this.RuleFor(x => x.Type).NotNull();
            this.RuleFor(x => x.Experience).NotNull();
            this.RuleFor(x => x.Salary).NotNull();

            this.Custom(x => 
            {
                var contractType = x.Type.GetValueOrDefault();
                var experience = x.Experience.GetValueOrDefault();
                var minWage = policy.GetMinimumWage(contractType, experience);
                var salary = calculator.Calculate(contractType, experience, minWage);

                return x.Salary != salary ? new ValidationFailure("salary", "The value does not match calculated value.") : null;
            });
        }
    }
}
