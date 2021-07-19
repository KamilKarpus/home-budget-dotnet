using HB.BuildingBlocks.Domain;
using HB.BuildingBlocks.Domain.ValueObjects;
using HB.Core.Domain.DomainEvents;
using System;

namespace HB.Core.Domain
{
    public class Budget : EventSourcedAggregate
    {
        public string Name { get; private set; }
        public Guid OwnerId { get; private set; }
        public Money Total { get; private set; }
        public Money TotalIncome { get; private set; }
        public Money TotalExpenditure { get; private set; }
        protected void CreateBudget(CreatedBudgetDomainEvent @event)
        {
            Id = @event.BudgetId;
            OwnerId = @event.OwnerId;
            Name = @event.Name;
            ApplyChange(@event);
        }
        public Budget()
        {
            RegisterHandler<CreatedBudgetDomainEvent>(CreateBudget);

        }

        public Budget(Guid id, string name, Guid ownerId)
        {
            Id = id;
            OwnerId = id;
            Name = name;
        }

        public static Budget Create(string name, Guid id, Guid ownerId)
        {
            var budget = new Budget();
            var @event = new CreatedBudgetDomainEvent(name, ownerId, id);
            budget.CreateBudget(@event);
            return budget;
        }

  

        
    }
}
