using FluentValidation;

namespace Headphones.Application.Dtos.HeadphonesDtos
{
    internal class HeadphoneCrudDtoValidation : AbstractValidator<HeadphoneCrudDto>
    {
        public HeadphoneCrudDtoValidation()
        {
            RuleFor(p => p.Name)
                .NotNull().NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than  zero");
        }
    }
}
