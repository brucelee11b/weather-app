using MassTransit;
using MediatR;

namespace MasstransitContract.Abstractions.Messages
{
    [ExcludeFromTopology]
    public interface IMessage : IRequest
    {
        public Guid Id { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
