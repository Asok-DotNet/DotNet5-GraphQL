
using System.Threading;
using System.Threading.Tasks;
using GraphQL.Data;
using GraphQL.GraphQL.Commands;
using GraphQL.GraphQL.Platforms;
using GraphQL.Models;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;

namespace GraphQL.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddPlatformPayload> AddPlatformAsync(AddPlatformInput input,
            [ScopedService] AppDbContext context,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {
            var platform = new Platform
            {
                Name = input.name
            };

            context.Platforms.Add(platform);

            await context.SaveChangesAsync(cancellationToken);

            await eventSender.SendAsync(nameof(Subscription.OnPlatformAdded), platform, cancellationToken);

            return new AddPlatformPayload(platform);

        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddCommandPayload> AddCommandAsync(AddCommandInput input,
            [ScopedService] AppDbContext context,
             CancellationToken cancellationToken)
        {
            var command = new Command
            {
                HowTo = input.howTo,
                CommandLine = input.commandLine,
                PlatformId = input.platformId
            };

            context.Commands.Add(command);

            await context.SaveChangesAsync(cancellationToken);

            return new AddCommandPayload(command);

        }
    }
}