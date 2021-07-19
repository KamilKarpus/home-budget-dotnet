using System;

namespace HB.BuildingBlocks.Domain.DomainEvents
{
    public abstract class DomainEventBase : IEvent
    {
        public Guid Id { get; private set; }
        public DateTime CreateDate { get; private set; }

        public DomainEventBase()
        {
            Id = Guid.NewGuid();
            CreateDate = DateTime.Now;
        }
    }
}
