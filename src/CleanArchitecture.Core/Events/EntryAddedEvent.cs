using DDDGuestbook.Core.Entities;
using DDDGuestbook.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDGuestbook.Core.Events
{
    public class EntryAddedEvent : BaseDomainEvent
    {
        public int GuestbookId { get; }
        public GuestbookEntry EntryAdded { get; }

        public EntryAddedEvent(int guestbookId, GuestbookEntry entryAdded)
        {
            GuestbookId = guestbookId;
            EntryAdded = entryAdded;
        }

        
    }
}
