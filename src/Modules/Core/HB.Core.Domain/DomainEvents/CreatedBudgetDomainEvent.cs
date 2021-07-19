using HB.BuildingBlocks.Domain.DomainEvents;
using System;

namespace HB.Core.Domain.DomainEvents
{
    public class CreatedBudgetDomainEvent : DomainEventBase
    {
        public string Name { get; private set; }
        public Guid OwnerId { get; private set; }
        public Guid BudgetId { get; private set; }

        public CreatedBudgetDomainEvent(string name, Guid ownerId, Guid budgetId)
        {
            Name = name;
            OwnerId = ownerId;
            BudgetId = budgetId;
        }
    }
}
