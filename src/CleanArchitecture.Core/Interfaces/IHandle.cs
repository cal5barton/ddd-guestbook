using DDDGuestbook.Core.SharedKernel;

namespace DDDGuestbook.Core.Interfaces
{
    public interface IHandle<T> where T : BaseDomainEvent
    {
        void Handle(T domainEvent);
    }
}