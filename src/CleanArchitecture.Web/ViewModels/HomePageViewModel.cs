using DDDGuestbook.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDDGuestbook.Web.ViewModels
{
    public class HomePageViewModel
    {
        public string GuestbookName { get; set; }
        public List<GuestbookEntry> PreviousEntries { get; } = new List<GuestbookEntry>();
    }
}
