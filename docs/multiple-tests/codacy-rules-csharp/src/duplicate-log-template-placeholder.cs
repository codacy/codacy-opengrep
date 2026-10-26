using Microsoft.Extensions.Logging;

namespace Tests.Practices
{
    class User { public int Id { get; set; } }
    class Order { public int Id { get; set; } }

    class Shop
    {
        public void Checkout(ILogger logger, User user, Order order)
        {
            logger.LogDebug("User {Id} purchased order {Id}", user.Id, order.Id); // Noncompliant
            logger.LogDebug("User {UserId} purchased order {OrderId}", user.Id, order.Id);
        }
    }
}
