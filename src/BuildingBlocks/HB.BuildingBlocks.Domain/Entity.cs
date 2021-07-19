using HB.BuildingBlocks.Domain.DomainEvents;
using System.Collections.Generic;

namespace HB.BuildingBlocks.Domain
{
    public class Entity
    {
        private List<DomainEventBase> _events;
        protected void AddDomainEvent(DomainEventBase @event)
        {
            _events = _events ?? new List<DomainEventBase>();
            _events.Add(@event);
        }
        public void ClearEvents()
        {
            _events.Clear();
        }
        public List<DomainEventBase> GetDomainEvents() => _events;
        
        
    }
}
