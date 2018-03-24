using Ardalis.GuardClauses;
using DDDGuestbook.Core.Events;
using DDDGuestbook.Core.Interfaces;

namespace DDDGuestbook.Core.Services
{
    public class ToDoItemService : IHandle<ToDoItemCompletedEvent>
    {
        public void Handle(ToDoItemCompletedEvent domainEvent)
        {
            Guard.Against.Null(domainEvent, nameof(domainEvent));

            // Do Nothing
        }
    }
}
