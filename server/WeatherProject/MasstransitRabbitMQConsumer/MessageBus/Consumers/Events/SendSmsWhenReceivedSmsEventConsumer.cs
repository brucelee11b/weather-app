using MasstransitContract.IntergrationEvents;
using MasstransitRabbitMQConsumer.Abstractions.Messages;
using MediatR;

namespace MasstransitRabbitMQConsumer.MessageBus.Consumers.Events
{
    public class SendSmsWhenReceivedSmsEventConsumer : Consumer<DomainEvent.SmsNotificationEvent>
    {
        public SendSmsWhenReceivedSmsEventConsumer(ISender sender) : base(sender)
        {
        }
    }
}
