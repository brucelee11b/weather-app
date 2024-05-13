using MasstransitContract.IntergrationEvents;
using MasstransitRabbitMQConsumer.Abstractions.Messages;
using MediatR;

namespace MasstransitRabbitMQConsumer.MessageBus.Consumers.Events
{
    public class SendEmailWhenReceivedEmailEventConsumer : Consumer<DomainEvent.EmailNotificationEvent>
    {
        public SendEmailWhenReceivedEmailEventConsumer(ISender sender) : base(sender)
        {
        }
    }
}
