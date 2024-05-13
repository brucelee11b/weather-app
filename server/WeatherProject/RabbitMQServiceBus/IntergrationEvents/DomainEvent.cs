using MasstransitContract.Abstractions.Messages;

namespace MasstransitContract.IntergrationEvents
{
    public static class DomainEvent
    {
        public record class EmailNotificationEvent : INotificationEvent
        {
            public Guid Id { get; set; }
            public DateTime TimeStamp { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Type { get; set; }
            public Guid TransactionId { get; set; }
        }

        public record class SmsNotificationEvent : INotificationEvent
        {
            public Guid Id { get; set; }
            public DateTime TimeStamp { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Type { get; set; }
            public Guid TransactionId { get; set; }
        }
    }
}
