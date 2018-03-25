using DDDGuestbook.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDGuestbook.Core.Interfaces
{
    public interface IGuestbookService
    {
        void RecordEntry(Guestbook guestbook, GuestbookEntry newEntry);
    }
}
