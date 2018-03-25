using DDDGuestbook.Core.Entities;
using DDDGuestbook.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDDGuestbook.Infrastructure.Data
{
    public class GuestbookRepository : EfRepository<Guestbook>, IGuestbookRepository
    {
        public GuestbookRepository(AppDbContext dbContext) : base(dbContext)
        {

        }

        public override Guestbook GetById(int id)
        {
            return _dbContext.Guestbooks
                .Include(g => g.Entries)
                .FirstOrDefault(g => g.Id == id);
        }

        public List<GuestbookEntry> ListEntries(ISpecifcation<GuestbookEntry> spec)
        {
            return _dbContext.Entries
                .Where(spec.Criteria)
                .ToList();
        }
    }
}
