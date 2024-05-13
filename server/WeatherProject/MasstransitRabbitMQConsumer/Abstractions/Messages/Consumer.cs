using MassTransit;
using MasstransitContract.Abstractions.Messages;
using MediatR;

namespace MasstransitRabbitMQConsumer.Abstractions.Messages
{
    public abstract class Consumer<TMessage> : IConsumer<TMessage> where TMessage : class, INotificationEvent
    {
        private readonly ISender Sender;

        protected Consumer(ISender sender)
        {
            Sender = sender;
        }

        public async Task Consume(ConsumeContext<TMessage> context)
            => await Sender.Send(context.Message);
    }
}
