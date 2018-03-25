using DDDGuestbook.Core.Entities;
using DDDGuestbook.Core.Events;
using DDDGuestbook.Core.Interfaces;
using DDDGuestbook.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDDGuestbook.Core.Handlers
{
    public class GuestbookNotificationHandler : IHandle<EntryAddedEvent>
    {
        private IGuestbookRepository _guestbookRepository;
        private IMessageSender _messageSender;

        public GuestbookNotificationHandler(IGuestbookRepository guestbookRepository, IMessageSender messageSender)
        {
            _guestbookRepository = guestbookRepository;
            _messageSender = messageSender;
        }

        public void Handle(EntryAddedEvent entryAddedEvent)
        {
            var guestbook = _guestbookRepository.GetById(entryAddedEvent.GuestbookId);

            //notify all previous entries if posted in last day
            var emailsToNotify = _guestbookRepository
                .ListEntries(new GuestbookNotificationPolicy(entryAddedEvent.EntryAdded.Id))
                .Select(e => e.EmailAddress);

            foreach (var emailAddress in emailsToNotify)
            {
                string messageBody = $"{entryAddedEvent.EntryAdded.EmailAddress} left a message {entryAddedEvent.EntryAdded.Message}";
                _messageSender.SendGuestbookNotificationEmail(emailAddress, messageBody);
            }
        }
    }
}
