using FluentValidation;
using HR.Contracts.Services.Dto;

namespace HR.Contracts.Services.Validators
{
    class ContractValidator : AbstractValidator<DtoContract>
    {
        public ContractValidator()
        {
            this.RuleFor(x => x.Name).NotNull().NotEmpty();
            this.RuleFor(x => x.Type).NotNull();
            this.RuleFor(x => x.Experience).NotNull();
            this.RuleFor(x => x.Salary).NotNull();
        }
    }
}
