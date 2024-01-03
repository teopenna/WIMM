using MediatR;

namespace Wimm.Api.Common.Events;

internal interface IIntegrationEventHandler<in TEvent> : INotificationHandler<TEvent> where TEvent : IIntegrationEvent;