using DDDGuestbook.Core.SharedKernel;

namespace DDDGuestbook.Core.Interfaces
{
    public interface IDomainEventDispatcher
    {
        void Dispatch(BaseDomainEvent domainEvent);
    }
}