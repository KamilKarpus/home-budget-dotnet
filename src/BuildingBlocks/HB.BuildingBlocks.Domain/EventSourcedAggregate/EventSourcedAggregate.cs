using HB.BuildingBlocks.Domain.DomainEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.BuildingBlocks.Domain
{
    public class EventSourcedAggregate : Entity
    {
        private readonly Dictionary<string, Action<IEvent>> _handlers = new Dictionary<string, Action<IEvent>>();
        public Guid Id { get; protected set; }
        public int Version { get; internal set; }

        protected void RegisterHandler<T>(Action<T> handler) where T : DomainEventBase
        {
            _handlers[nameof(T)] = e => handler((T)e);
        }

        public IEnumerable<DomainEventBase> GetUncommittedChanges()
        {
           return GetDomainEvents();
        }

        public void MarkChangesAsCommitted()
        {
            ClearEvents();
        }

        public void LoadsFromHistory(IEnumerable<DomainEventBase> history)
        {
            foreach (var e in history) ApplyChange(e, false);
        }

        protected void ApplyChange(DomainEventBase @event)
        {
            ApplyChange(@event, true);
        }
        private void ApplyChange(DomainEventBase @event, bool isNew)
        {
            _handlers[@event.GetType().Name].Invoke(@event);
            if (isNew) AddDomainEvent(@event);
        }
    }
}
}
