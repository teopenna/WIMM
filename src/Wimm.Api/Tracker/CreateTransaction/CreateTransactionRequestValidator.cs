using FluentValidation;

namespace Wimm.Api.Tracker.CreateTransaction;

internal sealed class CreateTransactionRequestValidator : AbstractValidator<CreateTransactionRequest>
{
    public CreateTransactionRequestValidator()
    {
        RuleFor(request => request.CategoryId).NotEmpty();
    }
}