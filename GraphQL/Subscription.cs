
using HotChocolate;
using GraphQL.Models;
using HotChocolate.Types;

namespace GraphQL.GraphQL
{
    public class Subscription
    {
        [Subscribe]
        [Topic]
        public Platform OnPlatformAdded([EventMessage] Platform platform) => platform;
    }
}