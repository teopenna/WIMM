using System.Reflection;

using Wimm.Api.Common.Events.EventBus.InMemory;

namespace Wimm.Api.Common.Events.EventBus;

internal static class EventBusModule
{
    internal static IServiceCollection AddEventBus(this IServiceCollection services) =>
        services.AddInMemoryEventBus(Assembly.GetExecutingAssembly());
}