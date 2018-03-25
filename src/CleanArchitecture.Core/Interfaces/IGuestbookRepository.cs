using DDDGuestbook.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDGuestbook.Core.Interfaces
{
    public interface IGuestbookRepository : IRepository<Guestbook>
    {
        List<GuestbookEntry> ListEntries(ISpecifcation<GuestbookEntry> spec);
    }
}
