using DDDGuestbook.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDGuestbook.Core.Entities
{
    public class GuestbookEntry : BaseEntity
    {
        public string EmailAddress { get; set; }
        public string Message { get; set; }
        public DateTimeOffset DateTimeCreated { get; set; } = DateTime.UtcNow;
    }
}
