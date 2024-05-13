using MasstransitContract.IntergrationEvents;
using MediatR;

namespace MasstransitRabbitMQConsumer.UseCases.Events
{
    public class SendSmsEventHandler : IRequestHandler<DomainEvent.SmsNotificationEvent>
    {
        private readonly ILogger _logger;
        public SendSmsEventHandler(ILogger<SendSmsEventHandler> logger)
        {
            _logger = logger;
        }
        public async Task Handle(DomainEvent.SmsNotificationEvent request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Message received: {message}", request);
        }
    }
}
