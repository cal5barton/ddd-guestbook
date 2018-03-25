using DDDGuestbook.Core.Entities;
using DDDGuestbook.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DDDGuestbook.Tests.Core.Entities
{
    public class GuestbookNotificationPolicyCriteriaShould
    {
        [Fact]
        public void IncludeEntriesFromLast24Hours()
        {
            var entries = TestEntries();
            var spec = new GuestbookNotificationPolicy(entries.First().Id);

            var entriesToNotify = entries.Where(spec.Criteria.Compile());

            Assert.Equal(1, entriesToNotify.Count());
        }

        [Fact]
        public void NotIncludeEntriesOver1DayOld()
        {
            var entries = TestEntries();
            var spec = new GuestbookNotificationPolicy(entries.First().Id);

            var entriesToNotify = entries.Where(spec.Criteria.Compile());
            Assert.True(entriesToNotify.Where(x => x.Id == 1).Count() == 0);
        }

        private List<GuestbookEntry> TestEntries()
        {
            return new List<GuestbookEntry>()
            {
                new GuestbookEntry(){ Id = 1, EmailAddress = "test@test.com", DateTimeCreated = DateTime.UtcNow.AddDays(-2)},
                new GuestbookEntry(){ Id = 2, EmailAddress = "test1@test.com", DateTimeCreated = DateTime.UtcNow.AddDays(-1)},
                new GuestbookEntry(){ Id = 3, EmailAddress = "test2@test.com", DateTimeCreated = DateTime.UtcNow}
            };
        }
    }
}
