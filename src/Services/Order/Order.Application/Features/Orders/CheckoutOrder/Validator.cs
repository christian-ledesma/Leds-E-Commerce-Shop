using FluentValidation;

namespace Order.Application.Features.Orders.CheckoutOrder
{
    public class Validator : AbstractValidator<CheckoutOrderCommand>
    {
        public Validator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("{UserName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{UserName} must not exceed 50 characters");

            RuleFor(x => x.EmailAddress)
                .NotEmpty().WithMessage("{EmailAddress} is required");

            RuleFor(x => x.TotalPrice)
                .NotEmpty().WithMessage("{TotalPrice} is required")
                .GreaterThan(0).WithMessage("{TotalPrice} should be greater than zero");
        }
    }
}
