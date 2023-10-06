using FluentValidation;

namespace Wimm.Api.Common.Validation.Requests;

internal static class RequestValidationExtensions
{
    internal static IServiceCollection AddRequestsValidations(this IServiceCollection services) =>
        services.AddValidatorsFromAssemblyContaining<Program>(includeInternalTypes: true);
}