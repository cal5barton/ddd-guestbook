using DDDGuestbook.Core.Entities;
using DDDGuestbook.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DDDGuestbook.Core.Specifications
{
    public class GuestbookNotificationPolicy : ISpecifcation<GuestbookEntry>
    {
        private readonly int _entryId;

        public GuestbookNotificationPolicy(int entryId)
        {
            _entryId = entryId;
        }

        public Expression<Func<GuestbookEntry, bool>> Criteria
        {
            get
            {
                return e =>
                e.DateTimeCreated > DateTimeOffset.UtcNow.AddDays(-1)
                && e.Id != _entryId;
            }
        }



    }
}
