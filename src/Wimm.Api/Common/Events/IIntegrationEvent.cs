using MediatR;

namespace Wimm.Api.Common.Events;

internal interface IIntegrationEvent : INotification
{
    Guid Id { get; }
    DateTimeOffset OccurredDateTime { get; }
}